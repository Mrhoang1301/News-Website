using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
namespace Magazine.Areas.Admin.Controllers
{
    public class ManageUserController : Controller
    {
        public ActionResult Index()
        {
            AccountModel model = new AccountModel();
            var user = model.listAllUsers();
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            AccountModel model = new AccountModel();
            model.DeleteAccount(id);
            return RedirectToAction("Index");
        }
    }
}
