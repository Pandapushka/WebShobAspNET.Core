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
    }
}
