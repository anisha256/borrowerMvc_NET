using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using borrower_NET.Models;
using System.Linq;
using System.Data.Entity;

namespace borrower_NET.Controllers
{
    [Authorize]
    public class BorrowerController : Controller
    {
        BM_DBEntities entity = new BM_DBEntities();
        // GET: Borrower
        public ActionResult Index()
        {
            return View(entity.BorrowersTbs.ToList());
        }

        //GET: Borrower/Details/1
        public ActionResult Details(int? id)
        {
            BorrowersTb borrower = entity.BorrowersTbs.Find(id);

            return View(borrower);
        }

        //GET: Borrower/Create
        public ActionResult Create()
        {
            return View();
        }


        //POST: Borrower/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,FullName,Address,MobileNumber,FundAmount,FundPurpose,BusinessType")] BorrowersTb borrower)
        {
            entity.BorrowersTbs.Add(borrower);
            entity.SaveChanges();
            return RedirectToAction("Index");


        }
        //GET: Borrower/Delete/id
        public ActionResult Delete(int? id)
        {

            BorrowersTb borrower = entity.BorrowersTbs.Find(id);
            if (borrower == null)
            {
                return HttpNotFound();
            }
            return View(borrower);

        }

        //POST: Borrower/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            BorrowersTb borrower = entity.BorrowersTbs.Find(id);
            entity.BorrowersTbs.Remove(borrower);
            entity.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Borrower/Edit/id
        public ActionResult Edit(int? id)
        {
            BorrowersTb borrower = entity.BorrowersTbs.Find(id);
            if(borrower == null)
            {
                return HttpNotFound();
            }
            return View(borrower);
        }

        //POST: Borrower/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,Address,MobileNumber ,FundAmount,FundPurpose,BusinessType")] BorrowersTb borrower)
        {
            if (ModelState.IsValid)
            {
               entity.Entry(borrower).State = EntityState.Modified;
                entity.SaveChanges();
                return RedirectToAction("index");

            }
            return View(borrower);
           
        }

    }
}