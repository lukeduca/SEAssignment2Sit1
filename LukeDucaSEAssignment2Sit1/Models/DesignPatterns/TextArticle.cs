using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LukeDucaSEAssignment2Sit1.Models.DesignPatterns.State;

namespace LukeDucaSEAssignment2Sit1.Models.DesignPatterns
{
    public class TextArticle: Article
    {
        private string articleDescription;

        public TextArticle(string articleName, DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId, int articleCommentId, int artId, string commentContent, IArticleState articleState, string articleDescription) : base(articleName, dateOfPublish, userId, mediaManagerId, articleStatusId, articleStateId, articleCommentId, artId, commentContent, articleState)
        {
            this.articleDescription = articleDescription;
        }

        public TextArticle(int artId, IArticleState articleState) : base(artId, articleState)
        {
        }

        public TextArticle()
        {
        }

        public override void CreateArticle(string articleName, string articleDescription, DateTime dateOfPublish, 
            int userId, int mediaManagerId, int articleStatusId, int articleStateId, int articleCommentId, 
            IArticleState articleState)
        {
            articleState.SubmitNewArticle(articleName, articleDescription, dateOfPublish, userId,
                mediaManagerId, articleStatusId, articleStateId, articleCommentId);            
        }

        public override void DeleteArticle(int articleId, IArticleState articleState)
        {
            articleState.DeleteConfirmed(articleId);
        }


        public override void UpdateArticle(int artId, string articleName, string articleDescription, DateTime dateOfPublish,
            int userId, int mediaManagerId, int articleStatusId, int articleStateId, int articleCommentId,
            IArticleState articleState)
        {
            articleState.SubmitUpdatedArticle(artId, articleName, articleDescription, dateOfPublish, userId,
                mediaManagerId, articleStatusId, articleStateId, articleCommentId);
        }


        public override void ReviewArticleByReviewer(int artId, string articleName, string articleDescription,
            DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId,
            int articleCommentId, string commentContent, IArticleState articleState)
        {
            articleState.AcceptOrRejectArticleByR(artId, articleName, articleDescription, dateOfPublish, userId,
                mediaManagerId, articleStatusId, articleStateId, commentContent, articleCommentId);
        }


        public override void ReviewArticleByMediaManager(int artId, string articleName, string articleDescription,
            DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId,
            int articleCommentId, string commentContent, IArticleState articleState)
        {
            articleState.AcceptOrRejectArticleByMm(artId, articleName, articleDescription, dateOfPublish, userId,
                mediaManagerId, articleStatusId, articleStateId, commentContent, articleCommentId);
        }
         
        
    }
}