using Application.DTOs;
using Core.Entity;

namespace Application.Mappers
{
    public static class ProductMapperDTO
    {
        public static Product MapToProduct(ProductDTO productDTO)
        {
            Guid categoryId = Guid.Parse("6e0a7d5e-4d8c-4f3a-9b2c-1e8e5f6a7b8c");
            var product = new Product(productDTO.Name, productDTO.Cost, productDTO.Description)
            {
                Id = productDTO.Id,
                CategoryId = categoryId
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
