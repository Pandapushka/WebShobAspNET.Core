using System.ComponentModel.DataAnnotations;

namespace WebShobGleb.Areas.Admin.Models
{
    public class RoleVM
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Название не может быть пустым!")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Поле долженно содержать от 2 до 30 символов")]
        public string Name { get; set; }
        public RoleVM()
        {
        }
    }
}
