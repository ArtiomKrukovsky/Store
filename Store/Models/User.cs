using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class User
    {
        [Required(ErrorMessage = "Отсутствует код пользователя")]
        [Display(Name = "Код пользователя")]
        public int UserId { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Недопустимое кол-во символов")]
        [Required(ErrorMessage = "Отсутствует имя пользовател")]
        [Display(Name = "Полное имя пользователя")]
        public string FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Недопустимое кол-во символов")]
        [Required(ErrorMessage = "Отсутствует Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(3, MinimumLength = 3, ErrorMessage = "Недопустимое кол-во символов")]
        [Required(ErrorMessage = "Отсутствует ваш пол")]
        [Display(Name = "Пол")]
        public string Gender { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Отсутствует дата рождения")]
        [Display(Name = "Дата рождения")]
        public DateTime Date_of_birthday { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Отсутствует дата создания")]
        [Display(Name = "Дата создания")]
        public DateTime Create_At { get; set; }

        [Range(1, 1000, ErrorMessage = "Недопустимая длинна кода")]
        [Required(ErrorMessage = "Отсутствует код страны")]
        [Display(Name = "Код страны")]
        public int CountryId { get; set; }


        public virtual Country Country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Seller> Sellers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Sellers = new List<Seller>();
            Orders= new List<Order>();
        }
    }
}