using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LukeDucaSEAssignment2Sit1.Models.DesignPatterns.State;

namespace LukeDucaSEAssignment2Sit1.Models.DesignPatterns
{
    public class TextArticle: ArticleFactory
    {
        
        private string articleName;
        private string articleDescription;
        private DateTime dateOfPublish;
        private int userId;
        private int mediaManagerId;
        private int articleStatusId;
        private int articleStateId;
        private int articleCommentId;

        private int artId;
        private string commentContent;

        private IArticleState articleState;

        //Empty Contstructor
        public TextArticle ()
        {
        }

        //Constructor
        public TextArticle(string articleName, string articleDescription, DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId, int articleCommentId, IArticleState articleState)
        {
            this.articleName = articleName;
            this.articleDescription = articleDescription;
            this.dateOfPublish = dateOfPublish;
            this.userId = userId;
            this.mediaManagerId = mediaManagerId;
            this.articleStatusId = articleStatusId;
            this.articleStateId = articleStateId;
            this.articleCommentId = articleCommentId;
            this.articleState = articleState;
        }

        //Constructor
        public TextArticle(int artId, string articleName, string articleDescription, DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId, int articleCommentId, string commentContent, IArticleState articleState)
        {
            this.artId = artId;
            this.articleName = articleName;
            this.articleDescription = articleDescription;
            this.dateOfPublish = dateOfPublish;
            this.userId = userId;
            this.mediaManagerId = mediaManagerId;
            this.articleStatusId = articleStatusId;
            this.articleStateId = articleStateId;
            this.articleCommentId = articleCommentId;
            this.commentContent = commentContent;
            this.articleState = articleState;
        }

        //Constructor
        public TextArticle(int articleId, IArticleState articleState)
        {
            this.artId = articleId;
            this.articleState = articleState;
        }

        //Constructor
        public TextArticle(int artId, string articleName, string articleDescription, DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId, int articleCommentId, IArticleState articleState)
        {
            this.artId = artId;
            this.articleName = articleName;
            this.articleDescription = articleDescription;
            this.dateOfPublish = dateOfPublish;
            this.userId = userId;
            this.mediaManagerId = mediaManagerId;
            this.articleStatusId = articleStatusId;
            this.articleStateId = articleStateId;
            this.articleCommentId = articleCommentId;
            this.articleState = articleState;
        }

        public override void CreateArticle()
        {
            base.CreateArticle();
            articleState.SubmitNewArticle(articleName, articleDescription, dateOfPublish, userId,
                mediaManagerId, articleStatusId, articleStateId, articleCommentId);
        }

        public override void DeleteArticle()
        {
            base.DeleteArticle();
            articleState.DeleteConfirmed(artId);
        }

        public override void UpdateArticle()
        {
            base.UpdateArticle();
            articleState.SubmitUpdatedArticle(artId, articleName, articleDescription, dateOfPublish, userId,
                mediaManagerId, articleStatusId, articleStateId, articleCommentId);
        }

        
        public override void ReviewArticleByReviewer()
        {
            base.ReviewArticleByReviewer();
            articleState.AcceptOrRejectArticleByR(artId, articleName, articleDescription, dateOfPublish, userId,
                mediaManagerId, articleStatusId, articleStateId, commentContent, articleCommentId);
        }

        public override void ReviewArticleByMediaManager()
        {
            base.ReviewArticleByMediaManager();
            articleState.AcceptOrRejectArticleByMm(artId, articleName, articleDescription, dateOfPublish, userId,
                mediaManagerId, articleStatusId, articleStateId, commentContent, articleCommentId);
        }

 
        
         

        
    }
}