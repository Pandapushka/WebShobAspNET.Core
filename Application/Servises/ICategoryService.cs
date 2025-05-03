using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servises
{
    public interface ICategoryService
    {
        void Add(CategoryDTO dTO);
        List<CategoryDTO> GetAll();
        CategoryDTO GetById(Guid id);
        void Delete(Guid id);
    }
}
