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
        public ActionResult Index(string searchBy, string searchValue)
        {
            var borrowerList = entity.BorrowersTbs.ToList();
            if (borrowerList.Count == 0)
            {
                TempData["Msg"] = "Currently,database is Empty";
            }
            else
            {
                //filter
                if(string.IsNullOrEmpty(searchValue))
                {
                    TempData["Msg"] = "Please provide search value";
                    return View(borrowerList);
                }
                else
                {
                    if(searchBy == "FullName")
                    {
                        var searchByFullName = borrowerList.Where(b => b.FullName == searchValue);
                        return View(searchByFullName);

                    }
                    if(searchBy == "Address")
                    {
                        var searchByAddress = borrowerList.Where(b => b.Address == searchValue);
                   return View(searchByAddress);
                            }
                }
            }
            return View(borrowerList);
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
        public ActionResult Create([Bind(Exclude = "Id")] BorrowersTb borrower)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.BorrowersTbs.Add(borrower);
                    entity.SaveChanges();
                    TempData["Msg"] = "Borrower Added Successfully";
                    return RedirectToAction("Create");

                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Failed to add Borrower" + e.Message;
                return RedirectToAction("Create");

            }
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