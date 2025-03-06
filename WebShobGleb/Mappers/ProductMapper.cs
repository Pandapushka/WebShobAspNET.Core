using OnlineShopDB.Models;
using WebShobGleb.Models;

namespace WebShobGleb.Mappers
{
    public class ProductMapper
    {
        public static Product ToProduct(ProductEdit productEdit)
        {
            return new Product(productEdit.Name, productEdit.Cost, productEdit.Description, "https://i.pinimg.com/736x/e5/ca/d2/e5cad2ec2eca38258096fe2caf0d8e28.jpg");
        }

        public static ProductVM MapToProductVM(Product product)
        {
            return new ProductVM(product.Name, product.Cost, product.Description, product.Image)
                   {
                        Id = product.Id // Устанавливаем Id отдельно, так как он не передается через конструктор
                   };
        }
        public static Product MapToProduct(ProductVM product)
        {
            return new Product(product.Name, product.Cost, product.Description, product.Image)
            {
                Id = product.Id // Устанавливаем Id отдельно, так как он не передается через конструктор
            };
        }
        public static List<ProductVM> MapToProductVMList(List<Product> products)
        {
            var productsVM = new List<ProductVM>();
            foreach (var product in products)
            {
                var productVM = MapToProductVM(product);
                productsVM.Add(productVM);
            }
            return productsVM;
        }
    }
}
