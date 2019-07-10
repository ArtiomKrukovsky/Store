using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class Seller
    {
        [Required(ErrorMessage = "Отсутствует код продовца")]
        [Display(Name = "Код продовца")]
        public int SellerId { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Недопустимое кол-во символов")]
        [Required(ErrorMessage = "Отсутствует имя продовца")]
        [Display(Name = "Имя продовца")]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Отсутствует дата создания")]
        [Display(Name = "Дата создания")]
        public DateTime Create_At { get; set; }

        [Range(1, 1000, ErrorMessage = "Недопустимая длинна кода")]
        [Required(ErrorMessage = "Отсутствует код страны")]
        [Display(Name = "Код страны")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Отсутствует код пользователя")]
        [Display(Name = "Код пользователя")]
        public int UserId { get; set; }

        public User User { get; set; }

        public Country Country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Product> Products { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Seller()
        {
            Products = new List<Product>();
        }
    }
}