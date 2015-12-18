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
    public class tbl_ArticleController : Controller
    {
        private DataContext db = new DataContext();

        // GET: tbl_Article
        public ActionResult Index()
        {
            var tbl_Article = db.tbl_Article.Include(t => t.tbl_ArticleStatus).Include(t => t.tbl_Users);
            return View(tbl_Article.ToList());
        }

        // GET: tbl_Article/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Article tbl_Article = db.tbl_Article.Find(id);
            if (tbl_Article == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Article);
        }

        // GET: tbl_Article/Create
        public ActionResult Create()
        {
            ViewBag.ArticleStatus_Id = new SelectList(db.tbl_ArticleStatus, "ArticleStatus_Id", "ArticleStatus_Type");
            ViewBag.User_Id = new SelectList(db.tbl_Users, "User_Id", "First_Name");
            return View();
        }

        // POST: tbl_Article/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Article_Id,Article_Name,Article_Description,Article_Commets_Content,Article_PublishDate,User_Id,MedaManager_Id,ArticleStatus_Id")] tbl_Article tbl_Article)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Article.Add(tbl_Article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticleStatus_Id = new SelectList(db.tbl_ArticleStatus, "ArticleStatus_Id", "ArticleStatus_Type", tbl_Article.ArticleStatus_Id);
            ViewBag.User_Id = new SelectList(db.tbl_Users, "User_Id", "First_Name", tbl_Article.User_Id);
            return View(tbl_Article);
        }

        // GET: tbl_Article/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Article tbl_Article = db.tbl_Article.Find(id);
            if (tbl_Article == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleStatus_Id = new SelectList(db.tbl_ArticleStatus, "ArticleStatus_Id", "ArticleStatus_Type", tbl_Article.ArticleStatus_Id);
            ViewBag.User_Id = new SelectList(db.tbl_Users, "User_Id", "First_Name", tbl_Article.User_Id);
            return View(tbl_Article);
        }

        // POST: tbl_Article/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Article_Id,Article_Name,Article_Description,Article_Commets_Content,Article_PublishDate,User_Id,MedaManager_Id,ArticleStatus_Id")] tbl_Article tbl_Article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleStatus_Id = new SelectList(db.tbl_ArticleStatus, "ArticleStatus_Id", "ArticleStatus_Type", tbl_Article.ArticleStatus_Id);
            ViewBag.User_Id = new SelectList(db.tbl_Users, "User_Id", "First_Name", tbl_Article.User_Id);
            return View(tbl_Article);
        }

        // GET: tbl_Article/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Article tbl_Article = db.tbl_Article.Find(id);
            if (tbl_Article == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Article);
        }

        // POST: tbl_Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Article tbl_Article = db.tbl_Article.Find(id);
            db.tbl_Article.Remove(tbl_Article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


       //Submitting a new article
        public ActionResult SubmitArticle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitArticle(tbl_Article a)
        {
            a.User_Id = db.tbl_Users.SingleOrDefault(x => x.Username == HttpContext.User.Identity.Name).User_Id;

            MyService.ServiceController myServiceController = new MyService.ServiceController();
            myServiceController.SubmitNewArticle(a.Article_Name, a.Article_Description,
                a.Article_Commets_Content, a.Article_PublishDate, a.User_Id, a.MedaManager_Id, a.ArticleStatus_Id,
                a.Article_State_Id);
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
