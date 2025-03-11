using OnlineShopDB.Models;
using WebShobGleb.Models;

namespace WebShobGleb.Mappers
{
    public class OrderMapper
    {
        public static OrderVM MapCartToOrderVM(Cart cart)
        {
            var orderVM = new OrderVM();
            orderVM.UserId = cart.UserId;
            orderVM.Items = cart?.Items.Select(item => new OrderItemVM
            {
                Id = item.Id,
                Product = item.Product,
                Amount = item.Amount
            }).ToList() ?? new List<OrderItemVM>();

            return orderVM;
        }
        public static OrderVM ToOrderVM(Cart cart, OrderVM orderVM)
        {
            if (cart == null)
            {
                return orderVM;
            }

            orderVM.UserId = cart.UserId;
            orderVM.Items = cart.Items.Select(item => new OrderItemVM
            {
                Id = item.Id,
                Product = item.Product,
                Amount = item.Amount
            }).ToList();

            return orderVM;
        }

        public static Order OrderForDb(OrderVM orderVM, Cart cart)
        {
            var order = new Order
            {
                Id = orderVM.Id,
                Name = orderVM.Name,
                Email = orderVM.Email,
                Phone = orderVM.Phone,
                Address = orderVM.Address,
                Status = OrderStatus.Created,
                CreateDateTime = DateTime.Now,
                Cost = orderVM.Cost
            };

            order.OrderItems = cart.Items.Select(item => new OrderItem
            {
                Id = Guid.NewGuid(),
                Product = item.Product,
                Amount = item.Amount,
                Order = order
            }).ToList();

            return order;
        }

        public static OrderVM MapOrderToOrderVM(Order order)
        {
            return new OrderVM
            {
                Id = order.Id,
                Name = order.Name,
                Email = order.Email,
                Phone = order.Phone,
                Address = order.Address,
                Status = order.Status,
                CreateDataTime = order.CreateDateTime,
                Items = order.OrderItems.Select(item => new OrderItemVM
                {
                    Id = item.Id,
                    Product = item.Product,
                    Amount = item.Amount,

                }).ToList()
            };
        }

        public static List<OrderVM> MapOrdersToOrderVMs(List<Order> orders)
        {
            return orders.Select(MapOrderToOrderVM).ToList();
        }
    }
}
