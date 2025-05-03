using Application.DTOs;
using Core.Entity;
using WebShobGleb.Models;

namespace WebShobGleb.Mappers
{
    public static class CartMapper
    {
        // ====== CartVM -> CartDTO ======
        public static CartDTO MapToCartDTO(CartVM cartVM)
        {
            if (cartVM == null) return null;

            return new CartDTO
            {
                Id = cartVM.Id,
                UserId = cartVM.UserId,
                Items = MapToCartItemDTOs(cartVM.Items)
            };
        }

        // ====== CartDTO -> CartVM ======
        public static CartVM MapToCartVM(CartDTO cartDTO)
        {
            if (cartDTO == null) return null;

            return new CartVM
            {
                Id = cartDTO.Id,
                UserId = cartDTO.UserId,
                Items = MapToCartItemVMs(cartDTO.Items)
            };
        }

        // ====== List<CartItemVM> -> List<CartItemDTO> ======
        public static List<CartItemDTO> MapToCartItemDTOs(List<CartItemVM> cartItemVMs)
        {
            if (cartItemVMs == null) return new List<CartItemDTO>();

            return cartItemVMs.Select(MapToCartItemDTO).ToList();
        }

        public static CartItemDTO MapToCartItemDTO(CartItemVM itemVM)
        {
            if (itemVM == null) return null;

            return new CartItemDTO
            {
                Id = itemVM.Id,
                Product = itemVM.Product,
                Amount = itemVM.Amount
            };
        }

        // ====== List<CartItemDTO> -> List<CartItemVM> ======
        public static List<CartItemVM> MapToCartItemVMs(List<CartItemDTO> cartItemDTOs)
        {
            if (cartItemDTOs == null) return new List<CartItemVM>();

            return cartItemDTOs.Select(MapToCartItemVM).ToList();
        }

        public static CartItemVM MapToCartItemVM(CartItemDTO itemDTO)
        {
            if (itemDTO == null) return null;

            return new CartItemVM
            {
                Id = itemDTO.Id,
                Product = itemDTO.Product,
                Amount = itemDTO.Amount
            };
        }
    }
}