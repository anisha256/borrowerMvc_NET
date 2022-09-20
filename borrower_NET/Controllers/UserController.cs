﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using borrower_NET.Models;

namespace borrower_NET.Controllers
{
    public class UserController : Controller
    {
        BM_DBEntities entity = new BM_DBEntities(); 

        // GET: User/Details/
        public ActionResult Details()
        {
            UsersTb user = entity.UsersTbs.Find(User.Identity.Name);
            return View(user);
        }
    }
}