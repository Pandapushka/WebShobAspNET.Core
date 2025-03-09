using OnlineShopDB.Models;
using System.ComponentModel.DataAnnotations;
using WebShobGleb.Models;

public class OrderVM
{
    public Guid Id { get; }
    [Required(ErrorMessage = "Поле ФИО должно быть заполнено")]
    [StringLength(70, MinimumLength = 3, ErrorMessage = "Имя должно содержать от 3 до 70 символов")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Поле Email должно быть заполнено")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Поле Телефон должно быть заполнено")]
    [StringLength(20, MinimumLength = 5, ErrorMessage = "Поле Телефон должно содержать от 5 до 20 символов")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Поле Адрес должно быть заполнено")]
    [StringLength(200, MinimumLength = 5, ErrorMessage = "Поле Адрес должно содержать от 5 до 200 символов")]
    public string Address { get; set; }

    public Guid CartVMId { get; set; }
    public string UserId { get; set; }

    // Список товаров в заказе
    public List<OrderItemVM> Items { get; set; } = new List<OrderItemVM>();

    public OrderStatus Status { get; set; }
    public DateTime CreateDataTime { get; set; }

    public decimal Cost
    {
        get
        {
            return Items?.Sum(x => x.Cost) ?? 0;
        }
    }

    public OrderVM()
    {
        Id = Guid.NewGuid();
        Items = new List<OrderItemVM>(); // Инициализация пустым списком
    }
}