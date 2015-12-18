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

        string SubmitNewArticle(string articleName, string articleDescription, string articleComments,
            DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId);
    }
}
