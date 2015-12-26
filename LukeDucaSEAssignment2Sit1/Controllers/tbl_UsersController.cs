using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using LukeDucaSEAssignment2Sit1.Models;
using System.Web.Security;
using System.Web.Routing;

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

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tbl_Users u)
        {
            try
            {
                MyService.ServiceController myServiceController = new MyService.ServiceController();
                string user = myServiceController.Login(u.Username, u.Password);

                if (user == "UserCredentialsMatched")
                {
                    FormsAuthentication.SetAuthCookie(u.Username, true);
                    //HttpContext.User = new GenericPrincipal();
                    ViewBag.GreetingMessage = "Welcome " + u.Username;
                    return View();
                }
                else
                {
                    ViewBag.Message = "Invalid Login Details - Please Try Again";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = "Invalid Login Details - Please Try Again";
                return View();
            }
        }

        //Register
        public ActionResult Register()
        {
            ViewBag.Role_Id = new SelectList(db.tbl_Roles, "Role_Id", "Type");
            return View();
        }

        [HttpPost]
        public ActionResult Register(tbl_Users u)
        {
            MyService.ServiceController myServiceController = new MyService.ServiceController();
            string newUser = myServiceController.Register(u.First_Name, u.Last_Name, u.Username, u.Password, u.Role_Id);
            ViewBag.Role_Id = new SelectList(db.tbl_Roles, "Role_Id", "Type");
            return View();
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
