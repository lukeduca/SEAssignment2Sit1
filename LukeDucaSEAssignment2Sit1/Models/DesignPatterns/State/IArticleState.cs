using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LukeDucaSEAssignment2Sit1.Models.DesignPatterns.State
{
    public interface IArticleState
    {

        void SubmitArticle();

        string SubmitNewArticle(string articleName, string articleDescription, DateTime dateOfPublish, int userId, 
            int mediaManagerId, int articleStatusId, int articleStateId, int articleCommentId);

        void AcceptOrRejectArticle();

        string AcceptOrRejectArticleByR(int artId, string articleName, string articleDescription, DateTime dateOfPublish,
            int userId, int mediaManagerId, int articleStatusId, int articleStateId, string commentContent,
            int articleCommentId);

        string AcceptOrRejectArticleByMm(int artId, string articleName, string articleDescription,
            DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId,
            string commentContent, int articleCommentId);

        int DeleteConfirmed(int artId);

        string SubmitUpdatedArticle(int artId, string articleName, string articleDescription, DateTime dateOfPublish,
            int userId, int mediaManagerId, int articleStatusId, int articleStateId, int articleCommentId);

    }
}
