using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using borrower_NET.Models;
using System.Linq;

namespace borrower_NET.Controllers
{
    public class AccountController : Controller
    {
        BM_DBEntities entity = new BM_DBEntities();
        
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel credentials)
        {
            bool userExists = entity.UsersTbs.Any(x=>x.Username == credentials.Username && x.Pincode == credentials.Pincode);
           //gives one username if present
            UsersTb u = entity.UsersTbs.FirstOrDefault(x => x.Username == credentials.Username && x.Pincode == credentials.Pincode);
            if (userExists)
            {
                FormsAuthentication.SetAuthCookie(u.Username,false);
                return RedirectToAction("Index","Borrower");
            }
            ModelState.AddModelError("", "Invalid Credentials");
            return View();

        }
        [HttpPost]
        public ActionResult Register(UsersTb userinfo)
        {
            entity.UsersTbs.Add(userinfo);
            entity.SaveChanges();
            return RedirectToAction("Login");
            
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}