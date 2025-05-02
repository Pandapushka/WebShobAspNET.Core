using Core.Entity;
using WebShobGleb.Models;

namespace WebShobGleb.Mappers
{
    public static class ProductMapper
    {
        public static Product MapToProduct(ProductVM productVM)
        {
            var product = new Product(productVM.Name, productVM.Cost, productVM.Description)
            {
                Id = productVM.Id
            };

            if (productVM.ImageFile != null)
            {
                using var memoryStream = new MemoryStream();
                productVM.ImageFile.CopyTo(memoryStream);
                var image = new Image
                {
                    FileName = productVM.ImageFile.FileName,
                    Data = memoryStream.ToArray(),
                    ContentType = productVM.ImageFile.ContentType
                };
                product.Images.Add(image);
            }

            return product;
        }

        public static ProductVM MapToProductVM(Product product)
        {
            return new ProductVM
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImageId = product.Images.FirstOrDefault()?.Id // Берем ID первого изображения
            };
        }

        public static List<ProductVM> MapToProductVMList(List<Product> products)
        {
            return products.Select(MapToProductVM).ToList();
        }
    }
}
