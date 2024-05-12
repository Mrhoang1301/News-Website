using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EntityFramework;

namespace DataAccess
{
    public class ArticleModel
    {
        private WizardMagazineDbContext context = null;
        public ArticleModel()
        {
            context = new WizardMagazineDbContext();
        }
        public List<article> listAllArticles()
        {
            var list = context.Database.SqlQuery<article>("GetALL_Articles").ToList();
            list.Reverse();
            return list;
        }
        public List<article> listFoundArticles(string titl)
        {
            object[] parameter = {
                new SqlParameter("@title", titl)
            };
            var list = context.Database.SqlQuery<article>("findArticles @title",parameter).ToList();
            list.Reverse();
            return list;
        }
        public int CreateArticle(string titlea, string textbodya, string imagea, int? user_id, int? cate_id)
        {
            object[] parameter = {
                new SqlParameter("@title", titlea),
                new SqlParameter("@textbody", textbodya),
                new SqlParameter("@image", imagea),
                new SqlParameter("@user_id", user_id),
                new SqlParameter("@cate_id", cate_id)
            };
            int res = context.Database.ExecuteSqlCommand("insert_article @title,@textbody,@image,@user_id,@cate_id", parameter);
            return res;
        }
        public int DeleteArticle(int article_id)
        {
            int res = context.Database.ExecuteSqlCommand("delete_article @art_id",
                new SqlParameter("@art_id", article_id)
            );
            return res;
        }

        public int UpdateArticle(article mart)
        {
            var res = context.Database.SqlQuery<article>("exec update_article1 @article_id, @title, @textbody, @image, @cateid",
                new SqlParameter("@article_id", mart.article_id),
                new SqlParameter("@title", mart.title),
                new SqlParameter("@textbody", mart.textbody),
                new SqlParameter("@image", mart.image),
                new SqlParameter("@cateid", mart.cate_id)
                ).FirstOrDefault();
            if (res != null)
                return res.article_id;
            return -1;
        }

        public article getByID(int id)
        {
            object[] parameter = {
                new SqlParameter("@id", id)
            };
            var arti = context.articles.SqlQuery("getArtById @id", parameter).FirstOrDefault();
            return arti;
        }


        public int getRowsCount()
        {
            var cntQuery = context.Database.SqlQuery<int>("countRowArticles");

            return cntQuery.First<int>();

        }
    }
}
