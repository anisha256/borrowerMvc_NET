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
 
        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel credentials)
        {
            if (ModelState.IsValid)
            {
            bool userExists = entity.UsersTbs.Any(x=>x.Username == credentials.Username && x.Pincode == credentials.Pincode);
           //gives one username if present
            UsersTb u = entity.UsersTbs.FirstOrDefault(x => x.Username == credentials.Username && x.Pincode == credentials.Pincode);
            if (userExists)
            {
              
                FormsAuthentication.SetAuthCookie(u.Username,false);
                return RedirectToAction("Index","Borrower");
            }
            else
                {
                    TempData["Msg"] = "Invalid Credentials";
                    return RedirectToAction("Login");

                }
                
            }
            return View();
        }

        //GET : /Account/Register
        public ActionResult Register()
        {
            return View();
        }

        //POST : /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Id,FullName,Username,MobileNumber,EmailId,Pincode")] UsersTb user)
        {
            if (ModelState.IsValid)
            {
                entity.UsersTbs.Add(user);
                entity.SaveChanges();
                TempData["RegMsg"] = "Registration Successful";

                return RedirectToAction("Register");

            }
            return View();
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult Register2()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register2( UsersTb userinfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.UsersTbs.Add(userinfo);
                    entity.SaveChanges();
                    TempData["RegMsg"] = "Registration Successful";
                    return RedirectToAction("Register2");
                }
                return View();

            }
            catch(Exception e)
            {
                TempData["RegMsg"] = "Failed to Register"+ e.Message;

                return RedirectToAction("Register2");


            }

        }
    }
}