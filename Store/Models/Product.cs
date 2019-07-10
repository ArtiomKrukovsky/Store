using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Отсутствует код продукта")]
        [Display(Name = "Код продукта")]
        public int ProductId { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Недопустимое кол-во символов")]
        [Required(ErrorMessage = "Отсутствует название продукта")]
        [Display(Name = "Название продукта")]
        public string Name { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Недопустимая цена")]
        [Required(ErrorMessage = "Отсутствует цена продукта")]
        [Display(Name = "Цена")]
        public int Price { get; set; }

        [StringLength(30, MinimumLength = 5, ErrorMessage = "Недопустимое кол-во символов")]
        [Required(ErrorMessage = "Отсутствует статус")]
        [Display(Name = "Статус")]
        public string Status { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Отсутствует дата создания")]
        [Display(Name = "Дата создания")]
        public DateTime Create_At { get; set; }

        [Required(ErrorMessage = "Отсутствует код продовца")]
        [Display(Name = "Код продовца")]
        public int SellerId { get; set; }

        public Seller Seller { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<OrderItem> OrderItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}