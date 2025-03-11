using OnlineShopDB.Models;
using WebShobGleb.Models;

namespace WebShobGleb.Mappers
{
    public class UserLikeProductsMapper
    {
        // Преобразование из UserLikeProducts в UserLikeProductsVM
        public static UserLikeProductsVM MapToUserLikeProductsVM(UserLikeProducts userLikeProducts)
        {
            return new UserLikeProductsVM
            {
                Id = userLikeProducts.Id,
                UserId = userLikeProducts.UserId,
                Products = userLikeProducts.Products
            };
        }

        // Преобразование из UserLikeProductsVM в UserLikeProducts
        public static UserLikeProducts MapToUserLikeProducts(UserLikeProductsVM userLikeProductsVM)
        {
            return new UserLikeProducts
            {
                Id = userLikeProductsVM.Id,
                UserId = userLikeProductsVM.UserId,
                Products = userLikeProductsVM.Products
            };
        }

        // Преобразование списка UserLikeProducts в список UserLikeProductsVM
        public static List<UserLikeProductsVM> MapToUserLikeProductsVMList(List<UserLikeProducts> userLikeProductsList)
        {
            return userLikeProductsList.Select(MapToUserLikeProductsVM).ToList();
        }

        // Преобразование списка UserLikeProductsVM в список UserLikeProducts
        public static List<UserLikeProducts> MapToUserLikeProductsList(List<UserLikeProductsVM> userLikeProductsVMList)
        {
            return userLikeProductsVMList.Select(MapToUserLikeProducts).ToList();
        }
    }
}
