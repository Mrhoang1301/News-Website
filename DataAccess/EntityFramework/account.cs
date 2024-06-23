using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class account
    {
        [Key]
        public int user_id { get; set; }
        public string usename { get; set; }
        public string email { get; set; }
        public string full_name { get; set; }
        public string password { get; set; }
        public string avatar { get; set; }
        public string sefl_des { get;set;}

        public ICollection<comment> comments { get; set; }

    }
}
