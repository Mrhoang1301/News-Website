using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataAccess.EntityFramework;
namespace DataAccess
{
    public class CategoryModel
    {
        private WizardMagazineDbContext context = null;
        public CategoryModel()
        {
            context = new WizardMagazineDbContext();
        }
        public List<category> listAllCate()
        {
            var list = context.Database.SqlQuery<category>("GetALL_Categories").ToList();
            list.Reverse();
            return list;
        }
        public int CreateCate(string name)
        {
            object[] parameter = {
                new SqlParameter("@name", name)
            };
            int res = context.Database.ExecuteSqlCommand("insert_category @name", parameter);
            return res;
        }
        public int DeleteCate(int  cateid)
        {
            object[] parameter = {
                new SqlParameter("@cateid", cateid)
            };
            int res = context.Database.ExecuteSqlCommand("delete_cate @cateid",
                new SqlParameter("@cateid", cateid)
            );
            return res;
        }

        public category getById(int id)
        {
            object[] parameter = {
                new SqlParameter("@var_id", id)
            };
            var cate = context.categories.SqlQuery("getCateById @var_id", parameter).FirstOrDefault();
            return cate;
        }

        public int UpdateCate(category cate)
        {
            object[] parameterr = {
                new SqlParameter("@var_id", cate.cate_id),
                new SqlParameter("@var_name", cate.cate_name)
            };
            int res = context.Database.ExecuteSqlCommand("exec update_cate @var_id,@var_name", parameterr);
            return res;
        }
        public int UpdateCate11(category cate)
        {
            object[] parameterr = {
                 new SqlParameter("@var_name", cate.cate_name),
                new SqlParameter("@var_id", cate.cate_id)               
            };
            var sql = @"update categories SET cate_name = @var_name	WHERE cate_id = @var_id;";
            int res = context.Database.ExecuteSqlCommand(sql, parameterr);
            return res;
        }
       
        public void UpdateCate12(category mcate)
        {
            var commandText = "UPDATE categories SET cate_name = @var_name WHERE cate_id = @var_id";
            var newValue = new SqlParameter("@var_name", mcate.cate_name);
            var myId = new SqlParameter("@var_id", mcate.cate_id);

            context.Database.ExecuteSqlCommand(commandText, new[]{newValue,myId});
        }

        public int getRowsCount()
        {
            var cntQuery = context.Database.SqlQuery<int>("countRowCategories");

           return cntQuery.First<int>();

        }
    }
}
