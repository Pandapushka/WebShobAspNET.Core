namespace OnlineShopDB.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public List<Image> Images { get; set; } = new List<Image>(); // Список изображений

        public Product(string name, decimal cost, string description)
        {
            Name = name;
            Cost = cost;
            Description = description;
        }

    }
}
