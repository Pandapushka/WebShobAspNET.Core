namespace WebShobGleb.Models
{
   
        public class ProductVM
        {

            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Cost { get; set; }
            public string Description { get; set; }
            public string Image { get; set; }
            public ProductVM(string name, decimal cost, string description, string image)
            {
                Name = name;
                Cost = cost;
                Description = description;
                Image = image;
            }
        }
    }

