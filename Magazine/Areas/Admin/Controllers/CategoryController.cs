using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using DataAccess.EntityFramework;
namespace Magazine.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var iplCategories = new CategoryModel();
            var model = iplCategories.listAllCate();
            return View(model);
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            category cate = new category();
            return View(cate);
        }
      

        // POST: Admin/Category/Create
        [HttpPost]
        public ActionResult Create(category collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var model = new CategoryModel();
                    int res = model.CreateCate(collection.cate_name);
                    if (res > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm mới thể loại không thành công!");
                    }
                }
                return View(collection);
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int id)
        {
            var iplCategory = new CategoryModel();
            var model = iplCategory.getById(id);
            return View(model);
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(category ecate)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {                

                     var model = new CategoryModel();
                     int res = model.UpdateCate(ecate);

                     if (res>0)
                     {
                         return RedirectToAction("Index");
                     }
                     else
                     {
                         ModelState.AddModelError("", "Chỉnh sửa thể loại không thành công!");
                       //  return Content("<script language='javascript' type='text/javascript'>alert('"+res+ecate.cate_name+"');</script>");
                     } 
                }
                return View(ecate);

            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            CategoryModel catemd = new CategoryModel();
            catemd.DeleteCate(id);
            return RedirectToAction("Index");
        }

        // POST: Admin/Category/Delete/5
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
