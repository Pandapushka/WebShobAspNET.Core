using Core.Entity;

namespace Application.DTOs
{
    public class CategoryDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
