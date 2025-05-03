using Application.DTOs;
using Core.Entity;

namespace Application.Mappers
{
    public static class ProductMapperDTO
    {
        public static Product MapToProduct(ProductDTO productDTO)
        {
            var product = new Product(productDTO.Name, productDTO.Cost, productDTO.Description)
            {
                Id = productDTO.Id
            };

            if (productDTO.ImageFile != null)
            {
                using var memoryStream = new MemoryStream();
                productDTO.ImageFile.CopyTo(memoryStream);
                var image = new Image
                {
                    FileName = productDTO.ImageFile.FileName,
                    Data = memoryStream.ToArray(),
                    ContentType = productDTO.ImageFile.ContentType
                };
                product.Images.Add(image);
            }

            return product;
        }

        public static ProductDTO MapToProductDTO(Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImageId = product.Images.FirstOrDefault()?.Id // Берем ID первого изображения
            };
        }

        public static List<ProductDTO> MapToProductVMList(List<Product> products)
        {
            return products.Select(MapToProductDTO).ToList();
        }
    }
}
