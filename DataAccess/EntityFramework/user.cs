namespace DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        [Key]
        public int user_id { get; set; }

        [Display(Name = "User name")]
        [Required(ErrorMessage = "Vui lòng không để trống username!")]
        public string usename { get; set; }

        [StringLength(256,ErrorMessage = "Số ký tự tối đa là 256!")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vui lòng không để trống email!")]
        public string email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Vui lòng không để trống password!")]
        public string password { get; set; }

        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Vui lòng không để trống full name!")]
        public string full_name { get; set; }

        [Display(Name = "Url avatar")]
        public string avatar { get; set; }

        [Display(Name = "Sefl description")]
        public string sefl_des { get; set; }
    }
}
