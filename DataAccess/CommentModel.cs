using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EntityFramework;
using System.Data.Sql;
using System.Data.SqlClient;
namespace DataAccess
{
    public class CommentModel
    {
        private WizardMagazineDbContext context = null;
        public CommentModel()
        {
            context = new WizardMagazineDbContext();
        }
        public List<comment> listAllComments()
        {
            var list = context.Database.SqlQuery<comment>("GetALL_Comments").ToList();
            list.Reverse();
            return list;
        }
        public int DeleteCmt(int cmt_id)
        {
            int res = context.Database.ExecuteSqlCommand("delete_cmt @cmt_id",
                new SqlParameter("@cmt_id", cmt_id)
            );
            return res;
        }
        public int getRowsCount()
        {
            var cntQuery = context.Database.SqlQuery<int>("countRowCmt");

            return cntQuery.First<int>();

        }
    }
}
