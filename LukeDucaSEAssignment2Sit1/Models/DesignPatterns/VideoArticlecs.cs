using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LukeDucaSEAssignment2Sit1.Models.DesignPatterns.State;

namespace LukeDucaSEAssignment2Sit1.Models.DesignPatterns
{
    public class VideoArticlecs: Article
    {

        public VideoArticlecs()
        {
        }

        public override void DeleteArticle(int artId, IArticleState articleState)
        {
            base.DeleteArticle(artId, articleState);
        }

        public override void UpdateArticle(int artId, string articleName, string articleDescription, DateTime dateOfPublish,
            int userId, int mediaManagerId, int articleStatusId, int articleStateId, int articleCommentId, IArticleState article)
        {
            //base.UpdateArticle();
        }

        public override void ReviewArticleByReviewer(int artId, string articleName, string articleDescription,
            DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId,
            int articleCommentId, string commentContent, IArticleState articleState)
        {
            //base.ReviewArticleByReviewer();
        }

        public override void ReviewArticleByMediaManager(int artId, string articleName, string articleDescription,
            DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId,
            int articleCommentId, string commentContent, IArticleState articleState)
        {
            //base.ReviewArticleByMediaManager();
        }

        public VideoArticlecs(string articleName, DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId, int articleCommentId, int artId, string commentContent, IArticleState articleState) : base(articleName, dateOfPublish, userId, mediaManagerId, articleStatusId, articleStateId, articleCommentId, artId, commentContent, articleState)
        {
        }
    }
}