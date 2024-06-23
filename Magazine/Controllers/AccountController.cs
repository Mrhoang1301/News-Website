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
    public class AccountController : Controller
    {
        AccountModel AccountModel { get; set; }
        public AccountController()
        {
            AccountModel = new AccountModel();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new AccountLoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(AccountLoginViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                account acc = AccountModel.Login(model.Email, model.Password);
                if (acc != null)
                {
                    Session["USER_SESSION"] = acc;
                    return RedirectToAction("Index", "HomePage");
                }
            } catch (Exception ex)
            {
            }
            ModelState.AddModelError("", "Có lỗi xảy ra ! Vui lòng kiểm tra lại Email và Mật khẩu !");
            Session["USER_SESSION"] = null;
            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new AccountRegisterViewModel());
        }

        [HttpPost]
        public ActionResult Register(AccountRegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (AccountModel.AccountCheckExists(model.UserName, model.Email))
            {
                ModelState.AddModelError("", "UserName và Email đã được đăng ký !");
                return View(model);
            }
            
            try
            {
                account acc = AccountModel.Register(model.UserName, model.Email, model.Password, model.FullName);
                
                if (acc != null)
                {
                    Session["USER_SESSION"] = acc;
                    return RedirectToAction("Index", "HomePage");
                }
            }
            catch (Exception ex)
            {
            }
            ModelState.AddModelError("", "Có lỗi xảy ra ! Vui lòng kiểm tra dữ liệu !");
            Session["USER_SESSION"] = null;
            return View(new AccountRegisterViewModel());
        }

        public ActionResult Logout()
        {
            Session["USER_SESSION"] = null;
            return Redirect("/");
        }
        
    }
}