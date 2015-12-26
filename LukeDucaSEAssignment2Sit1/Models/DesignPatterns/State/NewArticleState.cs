using System;
using System.Collections.Generic;
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