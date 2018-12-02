using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserTable.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        [StringLength(20, ErrorMessage = "Это поле должно быть от {2} до {1} символов", MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Middle Name")]
        [DataType(DataType.Text)]
        [StringLength(20, ErrorMessage = "Это поле должно быть от {2} до {1} символов", MinimumLength = 3)]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        [StringLength(20, ErrorMessage = "Это поле должно быть от {2} до {1} символов", MinimumLength = 3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string E_mail { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+[0-9]+[A-Za-z0-9._%+-]+", ErrorMessage = "Пароль должен содержать цифры")]
        [StringLength(30, ErrorMessage = "Это поле должно быть от {2} до {1} символов", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Re-enter Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string Re_Password { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Age")]
        [DataType(DataType.Text)]
        [Range(18, 99, ErrorMessage = "Недопустимый год")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"\+\([0-9]{3}\)-[0-9]{2}-[0-9]{3}-[0-9]{2}-[0-9]{2}", ErrorMessage = "Формат номера должен быть - +(nnn)-nn-nnn-nn-nn")]
        [StringLength(19, ErrorMessage = "Это поле должно быть {1} символов", MinimumLength = 19)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [Display(Name = "Address")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Это поле должно быть от {2} до {1} символов", MinimumLength = 20)]
        public string Address { get; set; }
    }
}