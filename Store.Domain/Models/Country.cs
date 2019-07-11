using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Domain.Models
{
    public class Country
    {
        [Range(1,1000, ErrorMessage ="Недопустимая длинна кода")]
        [Required(ErrorMessage ="Отсутствует код страны")]
        [Display(Name="Код страны")]
        public int CountryId { get; set; }

        [StringLength(30,MinimumLength =3, ErrorMessage ="Недопустимое кол-во символов для названия страны")]
        [Required(ErrorMessage = "Отсутствует название страны")]
        [Display(Name = "Название страны")]
        public string Name { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Недопустимое кол-во символов для названия континента")]
        [Required(ErrorMessage = "Отсутствует название континента")]
        [Display(Name = "Название континента")]
        public string Continent_Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<User> Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Seller> Sellers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Country()
        {
            Users = new List<User>();
            Sellers = new List<Seller>();
        }
    }
}