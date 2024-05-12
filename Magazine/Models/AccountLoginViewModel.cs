using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Magazine.Models
{
    public class AccountLoginViewModel
    {
        [Display(Name = "Tên người dùng")]
        [Required(ErrorMessage = "Địa chỉ email không được để trống !")]
        public string Email { get;set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống !")]
        public string Password { get;set;}
    }
}