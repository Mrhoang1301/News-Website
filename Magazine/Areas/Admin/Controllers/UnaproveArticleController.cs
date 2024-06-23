using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using DataAccess.EntityFramework;
namespace Magazine.Areas.Admin.Controllers
{
    public class UnaproveArticleController : Controller
    {
        public ActionResult Index()
        {
            var iplArticles = new ArticleModel();
            var model = iplArticles.listAllArticlesNotAproved();
            return View(model);
        }

        [HttpPost]
        public ActionResult Approve(int id)
        {
            var impArticle = new ArticleModel();
            var modell = impArticle.ApproveArticle(id);
            var artmodel = new CategoryModel();
            ViewBag.listCategories = artmodel.listAllCate();
            TempData["SuccessMessage"] = "Bài viết đã được duyệt thành công.";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ArticleModel catemd = new ArticleModel();
            catemd.DeleteArticle(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Cancel(int id)
        {
            string note = Request.Form["note"];
            ArticleModel catemd = new ArticleModel();
            catemd.CancelArticle(id, note);
            return RedirectToAction("Index");
        }

        // POST: Admin/Article/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
