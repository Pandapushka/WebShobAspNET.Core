using Core.Entity;
using Core.Entity.Enums;
using WebShobGleb.Models;
using Application.DTOs;

namespace WebShobGleb.Mappers
{
    public static class OrderMapper
    {
        // ====== Cart -> OrderVM ======
        public static OrderVM MapCartToOrderVM(Cart cart)
        {
            if (cart == null) return new OrderVM();

            return new OrderVM
            {
                UserId = cart.UserId,
                Items = cart.Items?.Select(item => new OrderItemVM
                {
                    Id = item.Id,
                    Product = item.Product,
                    Amount = item.Amount
                }).ToList() ?? new List<OrderItemVM>()
            };
        }

        // ====== Cart + OrderVM -> OrderVM ======
        public static OrderVM ToOrderVM(Cart cart, OrderVM orderVM)
        {
            if (cart == null || orderVM == null) return orderVM;

            orderVM.UserId = cart.UserId;
            orderVM.Items = cart.Items?.Select(item => new OrderItemVM
            {
                Id = item.Id,
                Product = item.Product,
                Amount = item.Amount
            }).ToList() ?? new List<OrderItemVM>();

            return orderVM;
        }

        // ====== OrderVM + Cart -> OrderDTO ======
        public static OrderDTO OrderForDTO(OrderVM orderVM, Cart cart)
        {
            var orderDTO = new OrderDTO
            {
                Id = orderVM.Id,
                Name = orderVM.Name,
                Email = orderVM.Email,
                Phone = orderVM.Phone,
                Address = orderVM.Address,
                CartVMId = orderVM.CartVMId,
                UserId = orderVM.UserId,
                Status = OrderStatus.Created,
                CreateDataTime = DateTime.Now,
                Items = cart.Items?.Select(item => new OrderItemDTO
                {
                    Id = item.Id,
                    Product = item.Product,
                    Amount = item.Amount
                }).ToList() ?? new List<OrderItemDTO>()
            };

            return orderDTO;
        }

        // ====== OrderDTO -> OrderVM ======
        public static OrderVM MapToOrderVM(OrderDTO orderDTO)
        {
            if (orderDTO == null) return new OrderVM();

            return new OrderVM
            {
                Id = orderDTO.Id,
                Name = orderDTO.Name,
                Email = orderDTO.Email,
                Phone = orderDTO.Phone,
                Address = orderDTO.Address,
                CartVMId = orderDTO.CartVMId,
                UserId = orderDTO.UserId,
                Status = orderDTO.Status,
                CreateDataTime = orderDTO.CreateDataTime,
                Items = orderDTO.Items?.Select(item => new OrderItemVM
                {
                    Id = item.Id,
                    Product = item.Product,
                    Amount = item.Amount
                }).ToList() ?? new List<OrderItemVM>()
            };
        }

        // ====== OrderVM -> OrderDTO ======
        public static OrderDTO MapToOrderDTO(OrderVM orderVM)
        {
            if (orderVM == null) return new OrderDTO();

            return new OrderDTO
            {
                Id = orderVM.Id,
                Name = orderVM.Name,
                Email = orderVM.Email,
                Phone = orderVM.Phone,
                Address = orderVM.Address,
                CartVMId = orderVM.CartVMId,
                UserId = orderVM.UserId,
                Status = orderVM.Status,
                CreateDataTime = orderVM.CreateDataTime,
                Items = orderVM.Items?.Select(item => new OrderItemDTO
                {
                    Id = item.Id,
                    Product = item.Product,
                    Amount = item.Amount
                }).ToList() ?? new List<OrderItemDTO>()
            };
        }

        public static List<OrderVM> MapToOrderVMList(List<OrderDTO> orderDTOs)
        {
            if (orderDTOs == null) return new List<OrderVM>();

            return orderDTOs.Select(MapToOrderVM).ToList();
        }
    }
}