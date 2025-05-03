using Microsoft.AspNetCore.Http;

namespace Application.DTOs
{
       public class ProductDTO
       {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public decimal Cost { get; set; }
            public string Description { get; set; }
            public Guid? ImageId { get; set; } // ID изображения
            public IFormFile ImageFile { get; set; }
            public ProductDTO()
            {
            }
            public ProductDTO(string name, decimal cost, string description)
            {
                    Name = name;
                    Cost = cost;
                    Description = description;
            }
       }

}

