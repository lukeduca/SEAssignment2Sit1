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
        private string articleComments;
        private DateTime dateOfPublish;
        private int userId;
        private int mediaManagerId;
        private int articleStatusId;
        private int articleStateId;

        private IArticleState articleState;

        public TextArticle ()
        {
        }

        public TextArticle(string articleName, string articleDescription, string articleComments, DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId, IArticleState articleState)
        {
            this.articleName = articleName;
            this.articleDescription = articleDescription;
            this.articleComments = articleComments;
            this.dateOfPublish = dateOfPublish;
            this.userId = userId;
            this.mediaManagerId = mediaManagerId;
            this.articleStatusId = articleStatusId;
            this.articleStateId = articleStateId;
            this.articleState = articleState;
        }

        

        public override void CreateArticle()
        {
            base.CreateArticle();
            articleState.SubmitNewArticle(articleName, articleDescription, articleComments, dateOfPublish, userId,
                mediaManagerId, articleStatusId, articleStateId);
        }

        public override void DeleteArticle()
        {
            base.DeleteArticle();
        }

        public override void UpdateArticle()
        {
            base.UpdateArticle();
        }

    }
}