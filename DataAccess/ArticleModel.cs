using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;

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
            var list = context.articles.Where(x => x.status == null).Include(x => x.category).ToList();
            list.Reverse();
            return list;
        }

        public List<article> listAllArticlesNotAproved()
        {
            var list = context.articles.Where(x => x.status ==1).Include(x => x.category).ToList();
            list.Reverse();
            return list;
        }

        public List<article> listAllArticlesCanceled()
        {
            var list = context.articles.Where(x => x.status == 2).Include(x => x.category).ToList();
            list.Reverse();
            return list;
        }

        public List<article> listAllArticlesPending(int userid)
        {
            var list = context.articles.Where(x => x.user_id == userid).Include(x => x.category).ToList();
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
                new SqlParameter("@cate_id", cate_id),
            };
            int res = context.Database.ExecuteSqlCommand("insert_article @title,@textbody,@image,@user_id,@cate_id", parameter);
            return res;
        }

        public int UserCreateArticle(string title, string textbody, string image, int? user_id, int? cate_id)
        {
            var article = new article
            {
                title = title,
                textbody = textbody,
                image = image,
                user_id = user_id,
                cate_id = cate_id,
                create_time = DateTime.Now,
                status = 1
            };

            context.articles.Add(article);
            return context.SaveChanges();
        }


        public int DeleteArticle(int article_id)
        {
            // Lấy tất cả các bình luận liên quan đến bài viết
            var comments = context.comments.Where(c => c.article_id == article_id).ToList();

            // Xóa các bình luận trước
            context.comments.RemoveRange(comments);

            // Xóa bài viết
            var article = context.articles.Find(article_id);
            context.articles.Remove(article);

            // Lưu thay đổi
            return context.SaveChanges();
        }

        public int ApproveArticle(int articleId)
        {
            var article = context.articles.Find(articleId);
            if (article != null)
            {
                article.status = null;
                context.SaveChanges();
                return articleId;
            }
            else
            {
                throw new Exception($"Article with ID {articleId} not found.");
            }
        }

        public int CancelArticle(int articleId, string cancelNote)
        {
            var article = context.articles.Find(articleId);
            if (article != null)
            {
                article.status = 2;
                article.note = cancelNote;
                context.SaveChanges();
                return articleId;
            }
            else
            {
                throw new Exception($"Article with ID {articleId} not found.");
            }
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

        public article getByID(int? id)
        {
            var arti = context.articles.FirstOrDefault(a => a.article_id == id && a.status == null);
            return arti;
        }


        public int getRowsCount()
        {
            var cntQuery = context.Database.SqlQuery<int>("countRowArticles");

            return cntQuery.First<int>();

        }
    }
}
