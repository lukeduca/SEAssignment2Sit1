using LukeDucaSEAssignment2Sit1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Services.Description;
using LukeDucaSEAssignment2Sit1.Models.DesignPatterns;

namespace LukeDucaSEAssignment2Sit1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceController" in both code and config file together.
    [ServiceContract]
    public interface IServiceController
    {       

        [OperationContract]
        void DoWork();

        [XmlSerializerFormat]
        [OperationContract]
        string Login(string uname, string pass);

        [XmlSerializerFormat]
        [OperationContract]
        string Register(string firstName, string lastName, string username, string password, int roleId);

        [XmlSerializerFormat]
        [OperationContract]
        void SubmitNewArticle(string articleName, string articleDescription,
            DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId,
            int articleStateId, int articleCommentId, string articleType);

        [XmlSerializerFormat]
        [OperationContract]
        void SubmitUpdatedArticle(int artId, string articleName, string articleDescription, DateTime dateOfPublish,
            int userId, int mediaManagerId, int articleStatusId, int articleStateId, string commentContent,
            int articleCommentId, string articleType);

        [XmlSerializerFormat]
        [OperationContract]
        void AcceptOrRejectArticleByReviewer(int artId, string articleName, string articleDescription,
            DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId,
            string commentContent, int articleCommentId, string articleType);

        [XmlSerializerFormat]
        [OperationContract]
        void AcceptOrRejectArticleByMediaManager(int artId, string articleName, string articleDescription,
            DateTime dateOfPublish, int userId, int mediaManagerId, int articleStatusId, int articleStateId,
            string commentContent, int articleCommentId, string articleType);

        [XmlSerializerFormat]
        [OperationContract]
        void DeleteArticle(int artId, string articleType);

     
        [OperationContract]
        Article get(int artID);
        
    }
}
