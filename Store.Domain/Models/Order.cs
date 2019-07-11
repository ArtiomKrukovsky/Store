using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Domain.Models
{
    public class Order
    {
        [Required(ErrorMessage = "Отсутствует код заказа")]
        [Display(Name = "Код заказа")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Отсутствует код пользователя")]
        [Display(Name = "Код пользователя")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [StringLength(30, MinimumLength = 5, ErrorMessage = "Недопустимое кол-во символов")]
        [Required(ErrorMessage = "Отсутствует статус")]
        [Display(Name = "Статус")]
        public string Status { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Отсутствует дата создания")]
        [Display(Name = "Дата создания")]
        public DateTime Create_At { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<OrderItem> OrderItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}