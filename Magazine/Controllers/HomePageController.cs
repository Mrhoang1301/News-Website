using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.EntityFramework;
using DataAccess;
namespace Magazine.Controllers
{
    public class HomePageController : Controller
    {
        public ActionResult Index(string searchst, int? cateId)
        {
            var iplArticles = new ArticleModel();
            var iplCate = new CategoryModel();
            var categories = iplCate.listAllCate();

            ViewBag.Categories = new SelectList(categories, "cate_id", "cate_name");

            var model = iplArticles.listAllArticles();

            if (!string.IsNullOrEmpty(searchst))
            {
                model = model.Where(s => s.title.ToLower().Contains(searchst) || s.title.ToUpper().Contains(searchst)).ToList();
            }
            if (cateId.HasValue)
            {
                model = model.Where(s => s.cate_id == cateId.Value).ToList();
            }
            return View(model);
        }


        public ActionResult PendingArticle()
        {
            var iplArticles = new ArticleModel();
            var iplCate = new CategoryModel();
            var categories = iplCate.listAllCate();
            var user = Session["USER_SESSION"] as account;
            ViewBag.Categories = new SelectList(categories, "cate_id", "cate_name");
            var model = iplArticles.listAllArticlesPending(user.user_id);
            return View(model);
        }

        public ActionResult Search(string m)
        {
            var iplArticles = new ArticleModel();
            var model = iplArticles.listFoundArticles(m);
            return View(model);
        }
        [HttpPost]
        public ActionResult Search1(string m)
        {
            var iplArticles = new ArticleModel();
            var model = iplArticles.listFoundArticles(m);
            return View(model);
        }

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

        /*        [HttpGet]
                public ActionResult getCommentByArticleId(int articleId)
                {
                    var commentModel = new CommentModel();
                    var comments = commentModel.GetCommentsByArticleId(articleId);
                    ViewBag.Comments = comments;
                    return View(commentModel);
                }*/

        [HttpPost]
        public ActionResult Comment(int articleId)
        {
            string commentContent = Request.Form["commentContent"];
           /* if (string.IsNullOrEmpty(commentContent))
            {
                ViewBag.CommentContentError = "Please enter a comment.";
                return View("Detail", articleId);
            }   */

            // Danh sách các từ ngữ nhạy cảm
            var sensitiveWords = new List<string> { "ditme", "dit", "lon" };

            // Thay thế các từ ngữ nhạy cảm bằng ký tự *
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


        public ActionResult Create()
        {
            var iplCate = new CategoryModel();
            var categories = iplCate.listAllCate();
            ViewBag.Categories = new SelectList(categories, "cate_id", "cate_name");
            var artmodel = new CategoryModel();
            ViewBag.listCategories = artmodel.listAllCate();
            return View(new article());
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(article mdarti)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = Session["USER_SESSION"] as account;
                    if (user.user_id == null)
                    {
                        RedirectToAction("Login", "Account");
                    }
                    var artmodel = new ArticleModel();
                    int iduser = user.user_id;
                    int ress = artmodel.UserCreateArticle(mdarti.title, mdarti.textbody, mdarti.image, iduser, mdarti.cate_id);
                    if (ress > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm mới bài viết không thành công!");
                    }
                }
                return View(mdarti);

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e + "Thêm mới bài viết không thành công!");
                return View(new article());
            }
        }
    }
}
