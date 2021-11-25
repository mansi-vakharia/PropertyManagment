using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyManagment.Controllers
{
    public class AccountController : Controller
    {
        PropertyManagmentEntities db = new PropertyManagmentEntities();
        public ActionResult Login(string msg="")
        {
            ViewBag.Msg = msg;
            return View(new User());
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            var data = db.Users.FirstOrDefault(w => w.Email.ToLower() == model.Email.ToLower()
             && w.Password == model.Password && w.UserType.ToLower() == model.UserType.ToLower());
            if (data != null)
            {
                Session["Id"] = data.Id;
                Session["FullName"] = data.FullName;
                Session["MobileNo"] = data.MobileNo;
                Session["Email"] = data.Email;
                Session["ImagePath"] = data.ImagePath;
                Session["UserType"] = data.UserType;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Session["Id"] = null;
                Session["FullName"] = null;
                Session["MobileNo"] = null;
                Session["Email"] = null;
                Session["ImagePath"] = null;
                Session["UserType"] = null;

                
            }
            //return View(new { msg= "Invalid login credentials" });
            return RedirectToAction("Login", "Account", new { msg = "Invalid login credentials" });
        }

        public ActionResult Logout()
        {
            Session["Id"] = null;
            Session["FullName"] = null;
            Session["MobileNo"] = null;
            Session["Email"] = null;
            Session["ImagePath"] = null;
            Session["UserType"] = null;
            return RedirectToAction("Login", "Account");
        }
    }
}