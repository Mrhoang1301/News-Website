using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Magazine.Areas.Admin.Models
{
    public class Account
    {

        public string email { get; set; }
        public string passWord { get; set; }
        public bool remember { get; set; }
    }
}