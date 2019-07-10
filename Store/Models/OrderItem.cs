using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        [Required(ErrorMessage = "Отсутствует код заказа")]
        [Display(Name = "Код заказа")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Отсутствует код продукта")]
        [Display(Name = "Код продукта")]
        public int ProductId { get; set; }

        [Range(1, 10, ErrorMessage = "Недопустимое кол-во")]
        [Required(ErrorMessage = "Отсутствует количество заказов")]
        [Display(Name = "Количество продукции")]
        public int Quantity { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}