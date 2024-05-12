using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Magazine.Models;
using DataAccess.EntityFramework;
using DataAccess;
using Magazine.Areas.Admin.Code;
using Magazine.Areas.Admin;
namespace Magazine.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Admin.Models.Account());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Admin.Models.Account acc)
        {
            var result = new UserModel().login(acc.email, acc.passWord);
            if (result && ModelState.IsValid)
            {
                SessionHelper.SetSession(new UserSession()
                {
                    email = acc.email
                });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng!");
            }
            return View(acc);
        }
    }
}