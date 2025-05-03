using Application.DTOs;
using Application.Mappers;
using Core.Repository;

namespace Application.Servises
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public void Add(CategoryDTO dTO)
        {
            _repository.Add(CategoryMapperDTO.ToCategory(dTO));
        }

        public List<CategoryDTO> GetAll()
        {
           return CategoryMapperDTO.ToCategoryDTOList(_repository.GetAll());
        }

        public CategoryDTO GetById(Guid id)
        {
             return CategoryMapperDTO.ToCategoryDTO(_repository.GetById(id));
        }
        public void Delete(Guid id)
        {
            var category = _repository.GetById(id);
            category.IsDeleted = true;
            _repository.Update(category);
        }
    }
}
