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
        // GET: HomePage
        public ActionResult Index(string searchst)
        {
            var iplArticles = new ArticleModel();
            var model = iplArticles.listAllArticles();
            if (searchst == null) { return View(model); } else
            {
                List<article> model1 = model.Where(s => s.title.Contains(searchst)).ToList(); //lọc theo chuỗi tìm kiếm                     
                return View(model1);
            }
            
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
        public ActionResult Test()
        {
            return View(new article());
        }

        // GET: HomePage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomePage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomePage/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HomePage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomePage/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HomePage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomePage/Delete/5
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

        public ActionResult Detail(int id)
        {

            var impArticle = new ArticleModel();
            var modell = impArticle.getByID(id);
            return View(modell);
        }
    }
}
