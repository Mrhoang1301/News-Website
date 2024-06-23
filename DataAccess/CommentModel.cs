using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EntityFramework;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Entity;
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

        public List<comment> GetCommentsByArticleId(int? articleId)
        {
            var comments = context.comments.Where(c => c.article_id == articleId).Include(c => c.Account).ToList();
            return comments;
        }

        public int CreateComment(comment newComment)
        {
            context.comments.Add(newComment);
            int res = context.SaveChanges();
            return res;
        }
        public int DeleteCmt(int cmt_id)
        {
            var cmt = context.comments.FirstOrDefault(x=>x.cmt_id.Equals(cmt_id));
            context.comments.Remove(cmt);
            int res = context.SaveChanges();
            return res;
        }
        public int getRowsCount()
        {
            var cntQuery = context.Database.SqlQuery<int>("countRowCmt");

            return cntQuery.First<int>();
        }
    }
}
