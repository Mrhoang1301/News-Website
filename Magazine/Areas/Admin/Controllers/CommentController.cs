using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
namespace Magazine.Areas.Admin.Controllers
{
    public class CommentController : Controller
    {
        // GET: Admin/Comment
        public ActionResult Index()
        {
            var iplCmt = new CommentModel();
            var model = iplCmt.listAllComments();
            return View(model);
        }

        // GET: Admin/Comment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Comment/Create
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

        // GET: Admin/Comment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Comment/Edit/5
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

        // GET: Admin/Comment/Delete/5
        public ActionResult Delete(int id)
        {
            CommentModel catemd = new CommentModel();
            catemd.DeleteCmt(id);
            return RedirectToAction("Index");
        }

        // POST: Admin/Comment/Delete/5
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
