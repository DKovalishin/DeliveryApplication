using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeliveryApplication.Models.DataBase
{
    public class Order
    {
        public int Id { get; set; }
        public long OrderNumber { get; set; }

        [Required(ErrorMessage = "Введите название города отправителя!")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Название города 2-20 символов")]
        [Display(Name = "Город отправителя")]
        public string CityOfSender { get; set; }

        [Required(ErrorMessage = "Введите адрес отправителя!")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Название адреса 2-20 символов")]
        [Display(Name = "Адрес отправителя")]
        public string AddressOfSender { get; set; }

        [Required(ErrorMessage = "Введите название города получателя!")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Название города 2-20 символов")]
        [Display(Name = "Город получателя")]
        public string CityOfRecipient { get; set; }

        [Required(ErrorMessage = "Введите адрес получателя!")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Название адреса 2-20 символов")]
        [Display(Name = "Адрес получателя")]
        public string AddressOfRecipient { get; set;}

        [Required(ErrorMessage = "Введите вес груза!")]
        [Display(Name = "Вес груза")]
        [Range(0, 100)]
        public double CargoWeight { get; set; }

        [Required(ErrorMessage = "Введите дату забора груза!")]
        [Display(Name ="Дата забора груза")]
        [DataType(DataType.Date)]
        public DateTime CargoPickupDate { get; set; }
    }

    public class OrderDBContext:DbContext
    {
        public DbSet<Order> orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=OrdersDB;Trusted_Connection=true");
        }
    }
}
