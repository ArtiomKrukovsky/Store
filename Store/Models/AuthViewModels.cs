using Store.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class LoginModel
    {
        [DataType(DataType.EmailAddress)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Недопустимое кол-во символов")]
        [Required(ErrorMessage = "Отсутствует Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(40, MinimumLength = 6, ErrorMessage = "Пароль должен содержать не менее 6 символов")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Отсутствует пароль")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

    }

    public class RegisterModel
    {
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Недопустимое кол-во символов")]
        [Required(ErrorMessage = "Отсутствует имя пользовател")]
        [Display(Name = "Полное имя пользователя")]
        public string FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Недопустимое кол-во символов")]
        [Required(ErrorMessage = "Отсутствует Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(40, MinimumLength = 6, ErrorMessage = "Пароль должен содержать не менее 6 символов")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Отсутствует пароль")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Compare("Password")]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "Пароль должен содержать не менее 6 символов")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Отсутствует пароль")]
        [Display(Name = "Проверка пароля")]
        public string PasswordConform { get; set; }

        [StringLength(3, MinimumLength = 3, ErrorMessage = "Недопустимое кол-во символов")]
        [Required(ErrorMessage = "Отсутствует ваш пол")]
        [Display(Name = "Пол")]
        public string Gender { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Отсутствует дата рождения")]
        [Display(Name = "Дата рождения")]
        public DateTime Date_of_birthday { get; set; }

        [Range(1, 1000, ErrorMessage = "Недопустимая длинна кода")]
        [Required(ErrorMessage = "Отсутствует код страны")]
        [Display(Name = "Код страны")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}