using Application.DTOs;
using Core.Entity;

namespace Web.Mappers
{
    public class CategoryMapper
    {
        public static Сategory ToCategory(CategoryDTO dTO)
        {
            if (dTO == null)
                return null;

            return new Сategory
            {
                Id = dTO.Id,
                Name = dTO.Name,
                IsDeleted = dTO.IsDeleted,

                // Если нужно скопировать список продуктов
                Products = dTO.Products ?? new List<Product>()
            };
        }

        public static CategoryDTO ToCategoryDTO(Сategory category)
        {
            if (category == null)
                return null;

            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                IsDeleted = category.IsDeleted,

                // Если нужно скопировать список продуктов
                Products = category.Products ?? new List<Product>()
            };
        }

        public static List<Сategory> ToCategoryList(List<CategoryDTO> dtoList)
        {
            if (dtoList == null)
                return new List<Сategory>();

            return dtoList.Select(ToCategory).ToList();
        }

        public static List<CategoryDTO> ToCategoryDTOList(List<Сategory> categoryList)
        {
            if (categoryList == null)
                return new List<CategoryDTO>();

            return categoryList.Select(ToCategoryDTO).ToList();
        }
    }
}
