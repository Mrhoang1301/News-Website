using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Magazine.Models;
using DataAccess;
using Magazine.Areas.Admin.Code;
using DataAccess.EntityFramework;

namespace Magazine.Controllers
{
    public class PendingArticleController : Controller
    {
        AccountModel AccountModel { get; set; }
        public PendingArticleController()
        {
            AccountModel = new AccountModel();
        }

        public ActionResult Index()
        {
            var iplArticles = new ArticleModel();
            var iplCate = new CategoryModel();
            var categories = iplCate.listAllCate();
            var user = Session["USER_SESSION"] as account;
            ViewBag.Categories = new SelectList(categories, "cate_id", "cate_name");
            var model = iplArticles.listAllArticlesPending(user.user_id);
            return View(model);
        }
    }
}