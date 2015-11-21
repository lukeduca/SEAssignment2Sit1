using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LukeDucaSEAssignment2Sit1.Models;

namespace LukeDucaSEAssignment2Sit1.Controllers
{
    public class tbl_UsersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: tbl_Users
        public ActionResult Index()
        {
            var tbl_Users = db.tbl_Users.Include(t => t.tbl_Roles);
            return View(tbl_Users.ToList());
        }

        // GET: tbl_Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Users tbl_Users = db.tbl_Users.Find(id);
            if (tbl_Users == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Users);
        }

        // GET: tbl_Users/Create
        public ActionResult Create()
        {
            ViewBag.Role_Id = new SelectList(db.tbl_Roles, "Role_Id", "Type");
            return View();
        }

        // POST: tbl_Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_Id,First_Name,Last_Name,Username,Password,Role_Id")] tbl_Users tbl_Users)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Users.Add(tbl_Users);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            ViewBag.Role_Id = new SelectList(db.tbl_Roles, "Role_Id", "Type", tbl_Users.Role_Id);
            return View(tbl_Users);
        }

        // GET: tbl_Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Users tbl_Users = db.tbl_Users.Find(id);
            if (tbl_Users == null)
            {
                return HttpNotFound();
            }
            ViewBag.Role_Id = new SelectList(db.tbl_Roles, "Role_Id", "Type", tbl_Users.Role_Id);
            return View(tbl_Users);
        }

        // POST: tbl_Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_Id,First_Name,Last_Name,Username,Password,Role_Id")] tbl_Users tbl_Users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Role_Id = new SelectList(db.tbl_Roles, "Role_Id", "Type", tbl_Users.Role_Id);
            return View(tbl_Users);
        }

        // GET: tbl_Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Users tbl_Users = db.tbl_Users.Find(id);
            if (tbl_Users == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Users);
        }

        // POST: tbl_Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Users tbl_Users = db.tbl_Users.Find(id);
            db.tbl_Users.Remove(tbl_Users);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
