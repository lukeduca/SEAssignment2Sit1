using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LukeDucaSEAssignment2Sit1.Models.DesignPatterns.State;
using Microsoft.Ajax.Utilities;

namespace LukeDucaSEAssignment2Sit1.Models.DesignPatterns
{
    public class ArticleFactory
    {
        public Article CreateTextArticleWithoutId(string articleName, string articleDescription, DateTime dateOfPublish,
            int userId,  int mediaManagerId, int articleStatusId, int articleStateId, 
            int articleCommentId, IArticleState articleState)
        {
            Article newArticle = new TextArticle(articleName, articleDescription, dateOfPublish, userId,
                mediaManagerId, articleStatusId, articleStateId, articleCommentId, articleState);

            return newArticle;
        }

        public Article CreateTextArticleWithId(int artId, string articleName, string articleDescription, 
            DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId,
            int articleCommentId, IArticleState articleState)
        {
            Article newArticle = new TextArticle(artId, articleName, articleDescription, dateOfPublish, userId,
            mediaManagerId, articleStatusId, articleStateId, articleCommentId, articleState);

            Article a = new tex

            return newArticle;
        }

        public Article CreateTextArticleWithCommentContent(int artId, string articleName, string articleDescription,
            DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId,
            int articleCommentId, string commentContent, IArticleState articleState)
        {
            Article newArticle = new TextArticle(artId, articleName, articleDescription, dateOfPublish, userId,
            mediaManagerId, articleStatusId, articleStateId, articleCommentId, commentContent, articleState);

            return newArticle;
        }

        public Article CreateTextArticleV4(int artId, IArticleState articleState)
        {
            Article newArticle = new TextArticle(artId, articleState);

            return newArticle;
        }

        public Article CreateVideoArticle()
        {
            Article newArticle = new VideoArticlecs();
            return newArticle;
        }
    }
}