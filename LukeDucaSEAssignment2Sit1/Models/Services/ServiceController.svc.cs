using LukeDucaSEAssignment2Sit1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Net;
using System.Data.Entity;
using LukeDucaSEAssignment2Sit1.Models.DesignPatterns;
using LukeDucaSEAssignment2Sit1.Models.DesignPatterns.State;

namespace LukeDucaSEAssignment2Sit1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceController" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceController.svc or ServiceController.svc.cs at the Solution Explorer and start debugging.
    public class ServiceController : IServiceController
    {
        private DataContext db = new DataContext();

        public void DoWork()
        {
        }

        public string Login(string uname, string pass)
        {
            if (db.tbl_Users.Where(x => x.Username == uname && x.Password == pass).Count() > 0)
            {
                return "UserCredentialsMatched";
            }
            else 
            {
                return null;
            }           
        }

        public string Register(string firstName, string lastName, string username, string password, int roleId)
        {
            string nUser = "";
            System.Net.ServicePointManager.DefaultConnectionLimit = 200;
            db.Configuration.ProxyCreationEnabled = false;

            tbl_Users newUser = new tbl_Users();
            newUser.First_Name = firstName;
            newUser.Last_Name = lastName;
            newUser.Username = username;
            newUser.Password = password;
            newUser.Role_Id = roleId;

            db.Entry(newUser).State = EntityState.Added;
            db.SaveChanges();

            if (newUser.Role_Id == 1)
            {
                //When article being subbmitted
                tbl_Workflows newWorkflowInStateId1 = new tbl_Workflows();
                newWorkflowInStateId1.User_Id = newUser.User_Id;
                newWorkflowInStateId1.State_Id = 1;
                db.Entry(newWorkflowInStateId1).State = EntityState.Added;
                db.SaveChanges();

                //When article being reviewed by Reviewer
                tbl_Workflows newWorkflowInStateId2 = new tbl_Workflows();
                newWorkflowInStateId2.User_Id = newUser.User_Id;
                newWorkflowInStateId2.State_Id = 2;
                db.Entry(newWorkflowInStateId2).State = EntityState.Added;
                db.SaveChanges();

                //When article being reviewed by Media Manager
                tbl_Workflows newWorkflowInStateId3 = new tbl_Workflows();
                newWorkflowInStateId3.User_Id = newUser.User_Id;
                newWorkflowInStateId3.State_Id = 3;
                db.Entry(newWorkflowInStateId3).State = EntityState.Added;
                db.SaveChanges();
            }

            if (nUser != "")
            {
                return nUser;
            }
            else
            {
                return null;
            }
        }

        public void SubmitNewArticle(string articleName, string articleDescription, DateTime dateOfPublish, int userId,
            int mediaManagerId, int articleStatusId, int articleStateId, int articleCommentId, string articleType)
        {
            ArticleFactory2 fac = null;
            IArticleState articleState = new NewArticleState();

            Type t = Type.GetType("LukeDucaSEAssignment2Sit1.Models.DesignPatterns.State.NewArticleState");
            if (articleType.Equals("TextArticle"))
            {
                fac = new TextArticleFactory();
                Article article = fac.create();
                TextArticle textArticle = (TextArticle)article;
                textArticle.CreateArticle(articleName, articleDescription, dateOfPublish, userId, mediaManagerId,
                    articleStatusId, articleStateId, articleCommentId, articleState);
            }
            else if (articleType.Equals("VideoArticle"))
            {
                fac = new VideoArticleFactory();
                Article article = fac.create();
                VideoArticlecs videoArticle = (VideoArticlecs)article;
            }
        }

        public void SubmitUpdatedArticle(int artId, string articleName, string articleDescription, DateTime dateOfPublish,
            int userId, int mediaManagerId, int articleStatusId, int articleStateId, string commentContent,
            int articleCommentId, string articleType)
        {
            ArticleFactory2 fac = null;
            IArticleState articleState = new NewArticleState();

            Type t = Type.GetType("LukeDucaSEAssignment2Sit1.Models.DesignPatterns.State.NewArticleState");
            if (articleType.Equals("TextArticle"))
            {
                fac = new TextArticleFactory();
                Article article = get(artId);
                TextArticle textArticle = (TextArticle) article;
                textArticle.UpdateArticle(artId, articleName, articleDescription, dateOfPublish, userId, mediaManagerId,
                    articleStatusId, articleStateId, articleCommentId, articleState);
            }
            else if (articleType.Equals("VideoArticle"))
            {
                fac = new VideoArticleFactory();
                Article article = get(artId);
                VideoArticlecs videoArticle = (VideoArticlecs)article;
            }

        }

        public void AcceptOrRejectArticleByReviewer(int artId, string articleName, string articleDescription,
            DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId, 
            string commentContent, int articleCommentId, string articleType)
        {
            ArticleFactory2 fac = null;
            IArticleState articleState = new NewArticleState();

            Type t =
                Type.GetType(
                    "LukeDucaSEAssignment2Sit1.Models.DesignPatterns.State.AcceptOrRejectArticleStateByReviewer");
            if (articleType.Equals("TextArticle"))
            {
                fac = new TextArticleFactory();
                Article article = get(artId);
                TextArticle textArticle = (TextArticle)article;
                textArticle.ReviewArticleByReviewer(artId, articleName, articleDescription, dateOfPublish, userId,
                    mediaManagerId, articleStatusId, articleStateId, articleCommentId, commentContent, (IArticleState)Activator.CreateInstance(t));
            }
            else if (articleType.Equals("VideoArticle"))
            {
                fac = new VideoArticleFactory();
                Article article = get(artId);
                VideoArticlecs videoArticle = (VideoArticlecs)article;
            }

        }

        public void AcceptOrRejectArticleByMediaManager(int artId, string articleName, string articleDescription, 
            DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId, 
            string commentContent, int articleCommentId, string articleType)
        {
            ArticleFactory2 fac = null;
            IArticleState articleState = new NewArticleState();
            Type t =
                Type.GetType(
                    "LukeDucaSEAssignment2Sit1.Models.DesignPatterns.State.AcceptOrRejectArticleStateByMediaManager");
            if (articleType.Equals("TextArticle"))
            {
                fac = new TextArticleFactory();
                Article article = get(artId);
                TextArticle textArticle = (TextArticle)article;
                textArticle.ReviewArticleByMediaManager(artId, articleName, articleDescription, dateOfPublish, userId,
                    mediaManagerId, articleStatusId, articleStateId, articleCommentId, commentContent,
                    (IArticleState) Activator.CreateInstance(t));
            }
            else if (articleType.Equals("VideoArticle"))
            {
                fac = new VideoArticleFactory();
                Article article = get(artId);
                VideoArticlecs videoArticle = (VideoArticlecs)article;
            }
        }

        public void DeleteArticle(int artId, string articleType)
        {
            ArticleFactory2 fac = null;
            IArticleState articleState = new NewArticleState();

            Type t = Type.GetType("LukeDucaSEAssignment2Sit1.Models.DesignPatterns.State.NewArticleState");
            if (articleType.Equals("TextArticle"))
            {
                fac = new TextArticleFactory();
                Article article = get(artId);
                TextArticle text = (TextArticle) article;
                text.DeleteArticle(artId, articleState);
            }
            else if (articleType.Equals("VideoArticle"))
            {
                fac = new VideoArticleFactory();
                Article article = get(artId);
                TextArticle text = (TextArticle) article;
            }
        }
        
        
        public Article get(int artID)
        {
            DataContext db = new DataContext();
            Article a = new TextArticle();

            a.ArtId = db.tbl_Article.SingleOrDefault(x => x.Article_Id == artID).Article_Id;
            return a;
        }

        
    }
         
         
}
