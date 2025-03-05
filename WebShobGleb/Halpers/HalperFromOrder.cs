using WebShobGleb.Models.DTO;
using WebShobGleb.Models;

namespace WebShobGleb.Halpers
{
    public class HalperFromOrder
    {
        public static CartAndOrderData MapCartToCartAndOrderData(Cart cart)
        {
            return new CartAndOrderData
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = cart.Items, 
                Amount = cart.Amount, 
                Cost = cart.Cost,    
            };
        }

        public static Order FormOrder(CartAndOrderData userOrder)
        {
            var order = new Order();
            order.Name = userOrder.Name;
            order.Address = userOrder.Address;
            order.Phone = userOrder.Phone;
            order.Email = userOrder.Email;
            return order;
        }
    }
}
