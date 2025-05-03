using Core.Entity;

namespace Web.ViewModels
{
    public class CategoryVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
