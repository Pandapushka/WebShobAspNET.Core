

namespace WebShobGleb.Areas.Admin.Models
{
    public class Role
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public Role()
        {
            Id = Guid.NewGuid();
        }
    }
}
