using Core.Entity;

namespace WebShobGleb.Models;

public class UserLikeProductsVM
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public List<Product> Products { get; set; }
}
