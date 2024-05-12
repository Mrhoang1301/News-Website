using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.EntityFramework;
using DataAccess;
namespace Magazine.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            int cateRows = new CategoryModel().getRowsCount();

            int cateCMTs = new CommentModel().getRowsCount();

            int cateArts = new ArticleModel().getRowsCount();

            int cateUsers = new UserModel().getRowsCount();

            ViewBag.rCate = cateRows;
            ViewBag.rCMT = cateCMTs;
            ViewBag.rArt = cateArts;
            ViewBag.rUser = cateUsers;

            return View();
        }
    }
}