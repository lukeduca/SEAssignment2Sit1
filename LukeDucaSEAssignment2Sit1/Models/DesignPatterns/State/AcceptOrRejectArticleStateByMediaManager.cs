using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LukeDucaSEAssignment2Sit1.Models.DesignPatterns.State
{
    public class AcceptOrRejectArticleStateByMediaManager : IArticleState
    {
        private DataContext db = new DataContext();
        private TextArticle textArticle;

        public AcceptOrRejectArticleStateByMediaManager()
        {
        }

        public AcceptOrRejectArticleStateByMediaManager(TextArticle textArticle)
        {
            this.textArticle = textArticle;
        }

        public void AcceptOrRejectReviewedArticle()
        {
            throw new NotImplementedException();
        }

        public string AcceptOrRejectArticleByMm(int artId, string articleName, string articleDescription, DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId, string commentContent, int articleCommentId)
        {
            string uArticle = "";

            System.Net.ServicePointManager.DefaultConnectionLimit = 200;
            db.Configuration.ProxyCreationEnabled = false;

            tbl_Article updatedArticle = db.tbl_Article.SingleOrDefault(x => x.Article_Id == artId);
            updatedArticle.Article_Id = artId;
            updatedArticle.Article_Name = articleName;
            updatedArticle.Article_Description = articleDescription;
            updatedArticle.Article_PublishDate = dateOfPublish;
            updatedArticle.User_Id = userId;
            updatedArticle.MedaManager_Id = mediaManagerId;
            updatedArticle.ArticleStatus_Id = articleStatusId;
            if (articleStatusId == 4) //Accepted by Media Manager
            {
                updatedArticle.Article_State_Id = 2;
            }
            else if (articleStatusId == 5) //Rejected by Media Manager
            {
                updatedArticle.Article_State_Id = 3;
            }

            tbl_Comments newComment = new tbl_Comments();
            if (commentContent == null) //If article do not have a comment by a reviewer and 
            {                                            //media manager left the article without a comment too
                updatedArticle.ArticleComment_Id = null;
            }
            else
            {
                if (updatedArticle.ArticleComment_Id == null) //If media manager added the first comment to the article
                {
                    newComment.ArticleComment_Content = commentContent;
                    newComment.Article_Id = artId;
                    newComment.User_Id = userId;
                    db.Entry(newComment).State = EntityState.Added;
                    db.SaveChanges();

                    updatedArticle.ArticleComment_Id = newComment.ArticleComment_Id;
                }
                else if (updatedArticle.ArticleComment_Id != null) //If media manager replaced the comment of the reviewer
                {
                    newComment.ArticleComment_Id = Convert.ToInt32(updatedArticle.ArticleComment_Id);
                    newComment.ArticleComment_Content = commentContent;
                    newComment.Article_Id = artId;
                    newComment.User_Id = userId;
                    db.Entry(newComment).State = EntityState.Modified;
                    db.SaveChanges();

                    updatedArticle.ArticleComment_Id = newComment.ArticleComment_Id;
                }
            }
            db.Entry(updatedArticle).State = EntityState.Modified;
            db.SaveChanges();

            if (uArticle != "")
            {
                return uArticle;
            }
            else
            {
                return null;
            }
        }

        public void SubmitArticle()
        {
            throw new NotImplementedException();
        }

        public string SubmitNewArticle(string articleName, string articleDescription, DateTime dateOfPublish, int userId,
            int mediaManagerId, int articleStatusId, int articleStateId, int articleCommentId)
        {
            throw new NotImplementedException();
        }

        public void AcceptOrRejectArticle()
        {
            throw new NotImplementedException();
        }

        public string AcceptOrRejectArticleByR(int artId, string articleName, string articleDescription, DateTime dateOfPublish,
            int userId, int mediaManagerId, int articleStatusId, int articleStateId, string commentContent, int articleCommentId)
        {
            throw new NotImplementedException();
        }

    }
}