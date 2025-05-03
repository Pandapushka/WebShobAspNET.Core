using Application.DTOs;
using Application.Mappers;
using Core.Entity;
using Core.Repository;
using Microsoft.AspNetCore.Http;


namespace Application.Servises
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(
            ICartRepository cartRepository,
            IProductsRepository productsRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _cartRepository = cartRepository;
            _productsRepository = productsRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public CartDTO GetCart(string userId, string tempUser)
        {
            var tempUserId = userId ?? tempUser;
            var cart = _cartRepository.TryGetByUserId(tempUserId);
            return CartDTOMapper.MappingToCartDTO(cart);
        }

        public void AddProductToCart(Guid productId, string userId, string tempUser)
        {
            var product = _productsRepository.GetById(productId);
            if (product == null)
            {
                throw new InvalidOperationException("Товар не найден.");
            }

            var tempUserId = userId ?? tempUser;
            var existingCart = _cartRepository.TryGetByUserId(tempUserId);
            var newCartItem = new CartItem
            {
                Amount = 1,
                Product = product
            };

            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    UserId = tempUserId,
                    Items = new List<CartItem> { newCartItem }
                };
                _cartRepository.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(item => item.Product.Id == productId);
                if (existingCartItem != null)
                {
                    existingCartItem.Amount++;
                }
                else
                {
                    existingCart.Items.Add(newCartItem);
                }
                _cartRepository.Update(existingCart);
            }
        }

        public void RemoveProductFromCart(Guid productId, string userId, string tempUser)
        {
            var tempUserId = userId ?? tempUser;
            var existingCart = _cartRepository.TryGetByUserId(tempUserId);
            if (existingCart == null)
            {
                throw new InvalidOperationException("Корзина не найдена.");
            }

            var existingCartItem = existingCart.Items.FirstOrDefault(item => item.Product.Id == productId);
            if (existingCartItem == null)
            {
                throw new InvalidOperationException("Товар не найден в корзине.");
            }

            existingCartItem.Amount--;
            if (existingCartItem.Amount == 0)
            {
                existingCart.Items.Remove(existingCartItem);
                _cartRepository.RemoveCartItem(existingCartItem);
            }

            if (existingCart.Items.Count == 0)
            {
                _cartRepository.Remove(existingCart);
            }
            else
            {
                _cartRepository.Update(existingCart);
            }
        }

        public void ClearCart(string userId, string tempUser)
        {
            var tempUserId = userId ?? tempUser;
            var cart = _cartRepository.TryGetByUserId(tempUserId);
            if (cart != null)
            {
                _cartRepository.Remove(cart);
            }
        }

       

        // Перенос корзины из временной в постоянную (при аутентификации)
        public void MergeCarts(string tempUserId, string userId)
        {
            var tempCart = _cartRepository.TryGetByUserId(tempUserId);
            if (tempCart == null)
            {
                return; // Нет временной корзины
            }

            var userCart = _cartRepository.TryGetByUserId(userId);
            if (userCart == null)
            {
                // Если у пользователя нет корзины, просто переносим временную корзину
                tempCart.UserId = userId;
                _cartRepository.Update(tempCart);
            }
            else
            {
                // Если у пользователя уже есть корзина, объединяем товары
                foreach (var item in tempCart.Items)
                {
                    var existingItem = userCart.Items.FirstOrDefault(i => i.Product.Id == item.Product.Id);
                    if (existingItem != null)
                    {
                        existingItem.Amount += item.Amount;
                    }
                    else
                    {
                        userCart.Items.Add(item);
                    }
                }
                _cartRepository.Update(userCart);
                _cartRepository.Remove(tempCart); // Удаляем временную корзину
            }
        }
    }
}