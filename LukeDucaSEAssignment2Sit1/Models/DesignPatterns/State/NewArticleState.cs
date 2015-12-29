using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LukeDucaSEAssignment2Sit1.Models.DesignPatterns.State
{
    public class NewArticleState: IArticleState
    {
        private DataContext db = new DataContext();
        private TextArticle textArticle;

        public NewArticleState()
        {
        }

        public NewArticleState(TextArticle textArticle)
        {
            this.textArticle = textArticle;
        }

        public void SubmitArticle()
        {
            throw new NotImplementedException();
        }

        public string SubmitNewArticle(string articleName, string articleDescription, DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleCommentId, int articleStateId)
        {
            string nArticle = "";

            tbl_Article newArticle = new tbl_Article();
            newArticle.Article_Name = articleName;
            newArticle.Article_Description = articleDescription;
            newArticle.Article_PublishDate = dateOfPublish;
            newArticle.User_Id = userId;
            newArticle.MedaManager_Id = mediaManagerId;
            newArticle.ArticleStatus_Id = 1;
            newArticle.Article_State_Id = 1;
            newArticle.ArticleComment_Id = null;

            db.tbl_Article.Add(newArticle);
            db.SaveChanges();

            if (nArticle != "")
            {
                return nArticle;
            }
            else
            {
                return null;
            }
        }

        public void DeleteArticle()
        {
            throw new NotImplementedException();
        }

        public int DeleteConfirmed(int artId)
        {
            int article = 0;
            
            tbl_Article a = db.tbl_Article.SingleOrDefault(x => x.Article_Id == artId);
            tbl_Comments c = db.tbl_Comments.SingleOrDefault(x => x.Article_Id == artId);

            db.Entry(a).State = EntityState.Deleted;
            db.SaveChanges();

            db.Entry(c).State = EntityState.Deleted;
            db.SaveChanges();

            if (article != null)
            {
                return article;
            }
            else
            {
                //throw new Exception();
                return 0;
            }
        }

        public void UpdateRejectedArticle()
        {
            throw new NotImplementedException();
        }

        public string SubmitUpdatedArticle(int artId, string articleName, string articleDescription, DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId, int articleCommentId)
        {
            string uArticle = "";

            tbl_Article updatedArticle = db.tbl_Article.SingleOrDefault(x => x.Article_Id == artId);
            updatedArticle.Article_Id = artId;
            updatedArticle.Article_Name = articleName;
            updatedArticle.Article_Description = articleDescription;
            updatedArticle.Article_PublishDate = dateOfPublish;
            updatedArticle.User_Id = userId;
            updatedArticle.MedaManager_Id = mediaManagerId;
            updatedArticle.ArticleStatus_Id = 1;
            updatedArticle.Article_State_Id = 1;
            updatedArticle.ArticleComment_Id = articleCommentId;

            if (updatedArticle.ArticleComment_Id != null)
            {
                updatedArticle.ArticleComment_Id = articleCommentId;
            }
            else
            {
                updatedArticle.ArticleComment_Id = null;
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

        public void AcceptOrRejectArticle()
        {
            throw new NotImplementedException();
        }

        public string AcceptOrRejectArticleByR(int artId, string articleName, string articleDescription, DateTime dateOfPublish,
            int userId, int mediaManagerId, int articleStatusId, int articleStateId, string commentContent, int articleCommentId)
        {
            throw new NotImplementedException();
        }

        public string AcceptOrRejectArticleByMm(int artId, string articleName, string articleDescription, DateTime dateOfPublish,
            int userId, int mediaManagerId, int articleStatusId, int articleStateId, string commentContent, int articleCommentId)
        {
            throw new NotImplementedException();
        }
    }
}