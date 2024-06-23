using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using DataAccess.EntityFramework;
namespace Magazine.Areas.Admin.Controllers
{
    public class ArticleController : Controller
    {
        public ActionResult Index()
        {
            var iplArticles = new ArticleModel();
            var model = iplArticles.listAllArticles();
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
            TempData["ArticleId"] = id;
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

        public ActionResult Create()
        {
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
                    var artmodel = new ArticleModel();
                    int iduser = 4;
                    int ress = artmodel.CreateArticle(mdarti.title, mdarti.textbody, mdarti.image, iduser, mdarti.cate_id);
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

        public ActionResult Edit(int id)
        {
            var impArticle = new ArticleModel();
            var modell = impArticle.getByID(id);
            var artmodel = new CategoryModel();
            ViewBag.listCategories = artmodel.listAllCate();
            return View(modell);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(article kart)
        {
            var artmodel = new CategoryModel();
            ViewBag.listCategories = artmodel.listAllCate();

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Dữ liệu nhập không hợp lệ !");
                return View(kart);
            }

            try
            {
                var model = new ArticleModel();
                int res = model.UpdateArticle(kart);

                if (res > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Chỉnh sửa bài viết không thành công!");
                }
            }
            catch (Exception ex)
            {

            }
            return View(kart);
        }

        public ActionResult Delete(int id)
        {
            ArticleModel catemd = new ArticleModel();
            catemd.DeleteArticle(id);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCmt(int id)
        {
            int articleId = (int)TempData["ArticleId"];
            CommentModel catemd = new CommentModel();
            catemd.DeleteCmt(id);
            return RedirectToAction("Detail", new { id = articleId });
        }
    }
}
