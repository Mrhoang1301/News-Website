using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using DataAccess.EntityFramework;
namespace Magazine.Areas.Admin.Controllers
{
    public class DetailArticleController : Controller
    {
        public ActionResult Detail(int? id)
        {
            var iplCate = new CategoryModel();
            var categories = iplCate.listAllCate();
            ViewBag.Categories = new SelectList(categories, "cate_id", "cate_name");
            var impArticle = new ArticleModel();
            var modell = impArticle.getByID(id);
            var commentModel = new CommentModel();
            var comments = commentModel.GetCommentsByArticleId(id);
            ViewBag.Comments = comments;
            return View(modell);
        }

        [HttpPost]
        public ActionResult Comment(int articleId)
        {
            string commentContent = Request.Form["commentContent"];
            if (string.IsNullOrEmpty(commentContent))
            {
                ViewBag.CommentContentError = "Please enter a comment.";
                return View("Detail", articleId);
            }
            var sensitiveWords = new List<string> { "ditme", "dit", "lon" };
            foreach (var word in sensitiveWords)
            {
                if (commentContent.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    commentContent = commentContent.Replace(word, new string('*', word.Length));
                }
            }
            var commentModel = new CommentModel();
            var user = Session["USER_SESSION"] as account;
            if (user == null)
            {
                return RedirectToAction("Detail", new { id = articleId });
            }
            var newComment = new comment
            {
                article_id = articleId,
                cmt_cotnent = commentContent,
                create_time = DateTime.Now,
                user_id = user.user_id
            };
            int result = commentModel.CreateComment(newComment);
            if (result > 0)
            {
                TempData["SuccessMessage"] = "Bình luận đã được tạo thành công.";
            }
            else
            {
                TempData["ErrorMessage"] = "Không thể tạo bình luận. Vui lòng thử lại.";
            }
            return RedirectToAction("Detail", new { id = articleId });
        }
    }
}
