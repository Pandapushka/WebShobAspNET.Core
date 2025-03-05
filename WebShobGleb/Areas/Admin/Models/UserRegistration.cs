using System.ComponentModel.DataAnnotations;

namespace WebShobGleb.Areas.Admin.Models
{
    public class UserRegistration
    {
        [Required(ErrorMessage = "Поле не может быть пустым!")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Email должен содержать от 4 до 30 символов")]
        [EmailAddress]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым!")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Пароль должен содержать от 8 до 30 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым!")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Поле Телефон должно быть заполнено")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Поле Телефон должно содержать от 5 до 20 символов")]
        public string Phone { get; set; }
    }
}
