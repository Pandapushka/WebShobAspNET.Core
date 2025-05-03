using Application.DTOs;
using WebShobGleb.Models;

namespace Web.Mappers
{
    public static class ProductMapper
    {
        // ProductVM -> ProductDTO
        public static ProductDTO MapToProductDTO(ProductVM productVM)
        {
            if (productVM == null)
                return null;

            return new ProductDTO(productVM.Name, productVM.Cost, productVM.Description)
            {
                Id = productVM.Id,
                ImageId = productVM.ImageId,
                ImageFile = productVM.ImageFile
            };
        }

        // ProductDTO -> ProductVM
        public static ProductVM MapToProductVM(ProductDTO productDTO)
        {
            if (productDTO == null)
                return null;

            return new ProductVM(productDTO.Name, productDTO.Cost, productDTO.Description)
            {
                Id = productDTO.Id,
                ImageId = productDTO.ImageId,
                ImageFile = productDTO.ImageFile
            };
        }

        // List<ProductVM> -> List<ProductDTO>
        public static List<ProductDTO> MapToProductDTOList(List<ProductVM> productVMs)
        {
            if (productVMs == null)
                return new List<ProductDTO>();

            return productVMs.Select(MapToProductDTO).ToList();
        }

        // List<ProductDTO> -> List<ProductVM>
        public static List<ProductVM> MapToProductVMList(List<ProductDTO> productDTOs)
        {
            if (productDTOs == null)
                return new List<ProductVM>();

            return productDTOs.Select(MapToProductVM).ToList();
        }
    }
}