using System.ComponentModel.DataAnnotations;

namespace WebShobGleb.Areas.Admin.Models
{
    public class ChangePassword
    {
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым!")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Пароль должен содержать от 8 до 30 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым!")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
        public string ConfirmPassword { get; set; }
    }
}
