using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using LukeDucaSEAssignment2Sit1.Models;
using Microsoft.Ajax.Utilities;

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

        [Authorize]
        // GET: tbl_Article/Edit/5
       public ActionResult Edit(int? id)
        {
            tbl_Users curretUser = db.tbl_Users.SingleOrDefault(x => x.Username == HttpContext.User.Identity.Name);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Article tbl_Article = db.tbl_Article.Find(id);
            if (tbl_Article == null)
            {
                return HttpNotFound();
            }

           if (curretUser.Role_Id == 1)
           {
               ViewBag.ArticleStatus_Id =
                   new SelectList(
                       db.tbl_ArticleStatus.Where(
                           x => x.ArticleStatus_Id == 1 || x.ArticleStatus_Id == 2 || x.ArticleStatus_Id == 3),
                       "ArticleStatus_Id", "ArticleStatus_Type", tbl_Article.ArticleStatus_Id);
           }
           else if (curretUser.Role_Id == 2)
           {
               ViewBag.ArticleStatus_Id =
                   new SelectList(
                       db.tbl_ArticleStatus.Where(
                           x => x.ArticleStatus_Id == 4 || x.ArticleStatus_Id == 5),
                       "ArticleStatus_Id", "ArticleStatus_Type", tbl_Article.ArticleStatus_Id);
           }
           ViewBag.User_Id = new SelectList(db.tbl_Users, "User_Id", "First_Name", tbl_Article.User_Id);
           return View(tbl_Article);
        }

        // POST: tbl_Article/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_Article a)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(tbl_Article).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.ArticleStatus_Id = new SelectList(db.tbl_ArticleStatus, "ArticleStatus_Id", "ArticleStatus_Type", tbl_Article.ArticleStatus_Id);
            //ViewBag.User_Id = new SelectList(db.tbl_Users, "User_Id", "First_Name", tbl_Article.User_Id);
            //return View(tbl_Article);

            tbl_Users curretUser = db.tbl_Users.SingleOrDefault(x => x.Username == HttpContext.User.Identity.Name);

            //tbl_Article currArt = db.tbl_Article.SingleOrDefault(x => x.Article_Id == a.Article_Id);
            //a.Article_State_Id = currArt.Article_State_Id;

            if (curretUser.Role_Id == 1) //Reviewer
            {
                MyService.ServiceController myServiceController = new MyService.ServiceController();
                myServiceController.AcceptOrRejectArticleByReviewer(a.Article_Id, a.Article_Name, a.Article_Description,
                    a.Article_PublishDate, a.User_Id, a.MedaManager_Id, a.ArticleStatus_Id, a.Article_State_Id,
                    a.tbl_Comments.ArticleComment_Content, Convert.ToInt32(a.ArticleComment_Id), "TextArticle");

                ViewBag.ArticleStatus_Id = new SelectList(db.tbl_ArticleStatus, "ArticleStatus_Id", "ArticleStatus_Type");
                ViewBag.User_Id = new SelectList(db.tbl_Users, "User_Id", "First_Name");
                return View();
            }

            else if (curretUser.Role_Id == 2) //Media Manager
            {
                MyService.ServiceController myServiceController = new MyService.ServiceController();
                myServiceController.AcceptOrRejectArticleByMediaManager(a.Article_Id, a.Article_Name, a.Article_Description,
                    a.Article_PublishDate, a.User_Id, a.MedaManager_Id, a.ArticleStatus_Id, a.Article_State_Id,
                    a.tbl_Comments.ArticleComment_Content, Convert.ToInt32(a.ArticleComment_Id), "TextArticle");

                ViewBag.ArticleStatus_Id = new SelectList(db.tbl_ArticleStatus, "ArticleStatus_Id", "ArticleStatus_Type");
                ViewBag.User_Id = new SelectList(db.tbl_Users, "User_Id", "First_Name");
                return View();  
            }

            return View();

        }

        [Authorize]
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
            MyService.ServiceController myServiceController = new MyService.ServiceController();
            myServiceController.DeleteArticle(id, "TextArticle");
            return View();
        }
        
        /*[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Article tbl_Article = db.tbl_Article.Find(id);
            db.tbl_Article.Remove(tbl_Article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/

       //Submitting a new article
        [Authorize]
        public ActionResult SubmitArticle()
        {
            ViewBag.MediaManager_ID =
                   new SelectList(
                       db.tbl_Users.Where(
                           x => x.Role_Id == 2),
                       "User_Id", "Username");
            return View();
        }

        [HttpPost]
        public ActionResult SubmitArticle(tbl_Article a)
        {
            a.User_Id = db.tbl_Users.SingleOrDefault(x => x.Username == HttpContext.User.Identity.Name).User_Id;
           
            MyService.ServiceController myServiceController = new MyService.ServiceController();
            myServiceController.SubmitNewArticle(a.Article_Name, a.Article_Description, a.Article_PublishDate, a.User_Id, 
                a.MedaManager_Id, a.ArticleStatus_Id, a.Article_State_Id, Convert.ToInt32(a.ArticleComment_Id), "TextArticle");

            ViewBag.MediaManager_ID =
                    new SelectList(
                        db.tbl_Users.Where(
                            x => x.Role_Id == 2),
                        "User_Id", "Username");
            return View();
        }
       
        [Authorize]
        //Get Pending Articles
        public ActionResult GetPEndingArticles()
        {
            var articles =
                db.tbl_Article.Where(
                    x =>
                        x.tbl_ArticleStatus.ArticleStatus_Id == 1 &&
                        x.tbl_Users.Username != HttpContext.User.Identity.Name);

            if (articles.Any())
            {
                return View(articles);
            }
            else
            {
                ViewData["ErrMsg"] = "No Articles To Show";
                return View();
            }

        }

        //Get articles respective of the media manager that were accepted by the reviewer
        public ActionResult GetAcceptedArticlesByReviewer()
        {
            tbl_Users curretUser = db.tbl_Users.SingleOrDefault(x => x.Username == HttpContext.User.Identity.Name);

            var articles = db.tbl_Article.Where(
                x =>
                    x.tbl_ArticleStatus.ArticleStatus_Id == 2 &&
                    x.MedaManager_Id == curretUser.User_Id);

            if (articles.Any())
            {
                return View(articles);
            }
            else
            {
                ViewData["ErrMsg"] = "No Articles To Show";
                return View();
            }
            
        }

        //Get articles that where rejected by Reviewer or Media Manager respective to the logged in user
        //[Authorize(Roles = "MediaManager")]
        [Authorize]
        public ActionResult GetRejectedArticles()
        {
            tbl_Users curretUser = db.tbl_Users.SingleOrDefault(x => x.Username == HttpContext.User.Identity.Name);

            var articles = db.tbl_Article.Where(
                x =>
                    x.tbl_ArticleState.Article_State_Id == 4 &&
                    x.tbl_Users.Username == HttpContext.User.Identity.Name);

            return View(articles);
        }
        
        [Authorize(Roles = "Writer")]
        public ActionResult UpdateArticle(int? id)
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

        [HttpPost, ActionName("UpdateArticle")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateArticle(tbl_Article a)
        {
            a.User_Id = db.tbl_Users.SingleOrDefault(x => x.Username == HttpContext.User.Identity.Name).User_Id;

            tbl_Comments com = new tbl_Comments();
            com = db.tbl_Comments.SingleOrDefault(x => x.Article_Id == a.Article_Id);
            if (com == null)
            {
                com = new tbl_Comments();
            }
            
            string commentContent = "";

            if (com.ArticleComment_Id != 0)
            {
                a.ArticleComment_Id = com.ArticleComment_Id;
                commentContent = com.ArticleComment_Content;
            }
            else
            {
                a.ArticleComment_Id = null;
                commentContent = "";
            }

            MyService.ServiceController myServiceController = new MyService.ServiceController();
            myServiceController.SubmitUpdatedArticle(a.Article_Id, a.Article_Name, a.Article_Description,
                a.Article_PublishDate, a.User_Id, a.MedaManager_Id, a.ArticleStatus_Id, a.Article_State_Id,
                commentContent, Convert.ToInt32(a.ArticleComment_Id), "TextArticle");
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
