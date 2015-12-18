using LukeDucaSEAssignment2Sit1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Security;

namespace LukeDucaSEAssignment2Sit1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceController" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceController.svc or ServiceController.svc.cs at the Solution Explorer and start debugging.
    public class ServiceController : IServiceController
    {
        private DataContext db = new DataContext();

        public void DoWork()
        {
        }

        public string Login(string uname, string pass)
        {
            if (db.tbl_Users.Where(x => x.Username == uname && x.Password == pass).Count() > 0)
            {
                return "UserCredentialsMatched";
            }
            else 
            {
                return null;
            }           
        }

        public string Register(string firstName, string lastName, string username, string password, int roleId)
        {
            string nUser = "";
            System.Net.ServicePointManager.DefaultConnectionLimit = 200;
            db.Configuration.ProxyCreationEnabled = false;

            tbl_Users newUser = new tbl_Users();
            newUser.First_Name = firstName;
            newUser.Last_Name = lastName;
            newUser.Username = username;
            newUser.Password = password;
            newUser.Role_Id = roleId;

            db.Entry(newUser).State = EntityState.Added;
            db.SaveChanges();

            if (nUser != "")
            {
                return nUser;
            }
            else
            {
                return null;
            }
        }

    }
}
