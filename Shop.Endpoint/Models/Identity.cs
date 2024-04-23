using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Endpoint.Models
{
    public class UserViewModel
    {
        public int ID { get; set; }
        [Display(Name = "نام :")]
        public string FName { get; set; }
        [Display(Name = "نام خانوادگی :")]
        public string LName { get; set; }
        [Display(Name = "نام کاربری:")]
        public string UserName { get; set; }
        [Display(Name = "رایانامه:")]
        [EmailAddress(ErrorMessage = ("ایمیل الرامی است"))]
        public string Email { get; set; }
        [Display(Name = "شماره موبایل:")]
        public string PhonNumber { get; set; }
        [Display(Name = "گذرواژه:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "گذرواژه دوباره:")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
    }
    public class LoginViewModel
    {
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [Display(Name = "نام کاربری:")]
        public string UserName { get; set; }
        [Display(Name = "رایانامه:")]
        [EmailAddress(ErrorMessage = ("ایمیل الرامی است"))]
        public string Email { get; set; }
        [Display(Name = "گذرواژه:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "گذرواژه دوباره:")]
        [DataType(DataType.Password)]
        public string ReturnUrl { get; set; }
    }
    public class RoleViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }
}