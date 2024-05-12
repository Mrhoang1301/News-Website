using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class account
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string full_name { get; set; }
        public string password { get; set; }
        public string avtar { get; set; }
        public string sefl_des { get;set;}
    }
}
