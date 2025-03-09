using OnlineShopDB.Models;
using WebShobGleb.Models;

namespace WebShobGleb.Mappers
{
    public class OrderMapper
    {
        public static OrderVM ToOrderVM(Cart cart, OrderVM orderVM)
        {

            orderVM.CartVMId = cart.Id;
            orderVM.UserId = cart.UserId;
            orderVM.Items = CartMapper.ToCartItemViewModel(cart.Items);
            return orderVM;
        }
        public static Order OrderForDb(OrderVM orderVM, Cart cart)
        {
            var order = new Order();
            order.Id = orderVM.Id;
            order.Address = orderVM.Address;
            order.Cart = cart;
            order.Email = orderVM.Email;
            order.Name = orderVM.Name;
            order.Phone = orderVM.Phone;
            order.Cost = orderVM.Cost;
            return order;
        }
    }
}
