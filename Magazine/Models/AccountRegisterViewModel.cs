using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Magazine.Models
{
    public class AccountRegisterViewModel
    {
        [Display(Name = "Tên người dùng")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống !")]
        public string UserName { get;set; }
        [Display(Name = "Địa chỉ Email")]
        [Required(ErrorMessage = "Địa chỉ email không được để trống !")]
        public string Email { get;set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống !")]
        public string Password { get;set; }
        [Display(Name = "Tên đầy đủ")]
        [Required(ErrorMessage = "Tên đầy đủ không được để trống !")]
        public string FullName { get;set; }
    }
}