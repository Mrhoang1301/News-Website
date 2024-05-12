using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using DataAccess.EntityFramework;

namespace DataAccess
{
    public class AccountModel
    {
        private WizardMagazineDbContext context = null;
        public AccountModel()
        {
            context = new WizardMagazineDbContext();
        }
        public account Login(string email, string password)
        {
            object[] sqlParams =
            {
                new SqlParameter("@email", email),
                new SqlParameter("@password", password),
            };
            var res = context.Database.SqlQuery<account>("spAccountLogin @email, @password", sqlParams).SingleOrDefault();
            return res;
        }

        public account Register(string username, string email, string password, string fullname)
        {
            object[] sqlParams =
            {
                new SqlParameter("@username", username),
                new SqlParameter("@email", email),
                new SqlParameter("@password", password),
                new SqlParameter("@full_name", fullname),
            };
            var res = context.Database.SqlQuery<account>("spAccountRegister @username, @email,"
                               + " @password, @full_name", sqlParams).SingleOrDefault();
            return res;
        }

        public bool AccountCheckExists(string username, string email)
        {
            object[] sqlParams =
           {
                new SqlParameter("@username", username),
                new SqlParameter("@email", email)
            };
            var res = context.Database.SqlQuery<int>("spAccountCheckExists @username, @email", sqlParams)
                .SingleOrDefault();
            return res > 0;
        }
    }
}
