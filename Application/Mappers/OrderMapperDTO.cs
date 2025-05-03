using Application.DTOs;
using Core.Entity;
using Core.Entity.Enums;

namespace WebShobGleb.Mappers
{
    public class OrderMapperDTO
    {
        public static OrderDTO MapCartToOrderVM(Cart cart)
        {
            var orderVM = new OrderDTO();
            orderVM.UserId = cart.UserId;
            orderVM.Items = cart?.Items.Select(item => new OrderItemDTO
            {
                Id = item.Id,
                Product = item.Product,
                Amount = item.Amount
            }).ToList() ?? new List<OrderItemDTO>();

            return orderVM;
        }
        public static OrderDTO ToOrderVM(Cart cart, OrderDTO orderVM)
        {
            if (cart == null)
            {
                return orderVM;
            }

            orderVM.UserId = cart.UserId;
            orderVM.Items = cart.Items.Select(item => new OrderItemDTO
            {
                Id = item.Id,
                Product = item.Product,
                Amount = item.Amount
            }).ToList();

            return orderVM;
        }

        public static Order OrderForDb(OrderDTO orderVM, Cart cart)
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

        public static OrderDTO MapOrderToOrderVM(Order order)
        {
            return new OrderDTO
            {
                Id = order.Id,
                Name = order.Name,
                Email = order.Email,
                Phone = order.Phone,
                Address = order.Address,
                Status = order.Status,
                CreateDataTime = order.CreateDateTime,
                Items = order.OrderItems.Select(item => new OrderItemDTO
                {
                    Id = item.Id,
                    Product = item.Product,
                    Amount = item.Amount,

                }).ToList()
            };
        }

        public static List<OrderDTO> MapOrdersToOrderVMs(List<Order> orders)
        {
            return orders.Select(MapOrderToOrderVM).ToList();
        }
    }
}
