using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EntityFramework;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DataAccess
{
    public class UserModel
    {
        private WizardMagazineDbContext context = null;
        public UserModel()
        {
            context = new WizardMagazineDbContext();
        }
        public bool login(string email, string password)
        {
            object[] sqlParams =
            {
                new SqlParameter("@email", email),
                new SqlParameter("@password", password),
            };
            var res = context.Database.SqlQuery<bool>("accountlogin @email, @password", sqlParams).SingleOrDefault();
            return res;
        }
        public List<user> listAllUsers()
        {
            var list = context.Database.SqlQuery<user>("GetALL_Users").ToList();
            list.Reverse();
            foreach(var item in list)
            {
                
                int l = item.password.Length;
                item.password = "";
                while (l>0)
                {
                    item.password += "*";
                    l--;
                }

            }
            return list;
        }

        public int DeleteUser(int user_id)
        {
            int res = context.Database.ExecuteSqlCommand("delete_user @userid",
                new SqlParameter("@userid", user_id)
            );
            return res;
        }

        public int getRowsCount()
        {
            var cntQuery = context.Database.SqlQuery<int>("countRowUsers");
            return cntQuery.First<int>();

        }
    }
}
