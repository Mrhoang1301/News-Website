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
                model = model.Where(s => s.title.Contains(searchst)).ToList();
            }

            if (cateId.HasValue)
            {
                model = model.Where(s => s.cate_id == cateId.Value).ToList();
            }

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

        public ActionResult Detail(int id)
        {
            var iplCate = new CategoryModel();
            var categories = iplCate.listAllCate();
            ViewBag.Categories = new SelectList(categories, "cate_id", "cate_name");
            var impArticle = new ArticleModel();
            var modell = impArticle.getByID(id);
            return View(modell);
        }
    }
}
