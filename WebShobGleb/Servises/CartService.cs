using OnlineShopDB.Models;
using OnlineShopDB.Repository;
using WebShobGleb.Mappers;
using WebShobGleb.Models;


namespace WebShobGleb.Servises
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

        public CartVM GetCart(string userId)
        {
            var tempUserId = userId ?? GetTempUserId();
            var cart = _cartRepository.TryGetByUserId(tempUserId);
            return CartMapper.MappingToCartVM(cart);
        }

        public void AddProductToCart(int productId, string userId)
        {
            var product = _productsRepository.GetProduct(productId);
            if (product == null)
            {
                throw new InvalidOperationException("Товар не найден.");
            }

            var tempUserId = userId ?? GetTempUserId();
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
                _cartRepository.AddCart(newCart);
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
                _cartRepository.UpdateCart(existingCart);
            }
        }

        public void RemoveProductFromCart(int productId, string userId)
        {
            var tempUserId = userId ?? GetTempUserId();
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
                _cartRepository.RemoveCart(existingCart);
            }
            else
            {
                _cartRepository.UpdateCart(existingCart);
            }
        }

        public void ClearCart(string userId)
        {
            var tempUserId = userId ?? GetTempUserId();
            var cart = _cartRepository.TryGetByUserId(tempUserId);
            if (cart != null)
            {
                _cartRepository.RemoveCart(cart);
            }
        }

        // Получение временного идентификатора пользователя из сессии
        private string GetTempUserId()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
            {
                throw new InvalidOperationException("HTTP-контекст недоступен.");
            }

            var tempUserId = httpContext.Session.GetString("TempUserId");
            if (string.IsNullOrEmpty(tempUserId))
            {
                tempUserId = Guid.NewGuid().ToString();
                httpContext.Session.SetString("TempUserId", tempUserId);
            }

            return tempUserId;
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
                _cartRepository.UpdateCart(tempCart);
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
                _cartRepository.UpdateCart(userCart);
                _cartRepository.RemoveCart(tempCart); // Удаляем временную корзину
            }
        }
    }
}