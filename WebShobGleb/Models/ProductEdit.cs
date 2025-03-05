using System.ComponentModel.DataAnnotations;

namespace WebShobGleb.Models
{
    public class ProductEdit
    {
        [Required(ErrorMessage = "Название не может быть пустым!")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Поле долженно содержать от 4 до 30 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле цена не может быть пустым!")]
        [Range(1, 100000, ErrorMessage = "Цена может быть в диапозоне от 1 до 100000")]
        public decimal Cost { get; set; }
        [Required(ErrorMessage = "Описание не может быть пустым!")]
        [StringLength(3000, MinimumLength = 30, ErrorMessage = "Поле долженно содержать 30 от  до 3000 символов")]
        public string Description { get; set; }
    }
}
