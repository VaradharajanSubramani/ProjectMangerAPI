using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMangerAPI.Controllers;
using ProjectManager.Entities;

namespace ProjectMangerAPI.Tests.Controllers
{
    [TestClass]
    public class UsersControllerTest
    {
        UsersController usr = new UsersController();
       /* [TestMethod]
        public void GetAllUsers_test()
        {
            var users = usr.GetAllUsers();
            Assert.AreEqual(users.Count(), 5);
        }

        [TestMethod]
        public void GetUserdetails_test()
        {
            var user = usr.GetUserDetails(1);
            Assert.AreEqual(user.LastName, "Subramani");
        }

        [TestMethod]
        public void DeleteUser()
        {
            int userid = 1005;
            usr.DeleteUser(userid);
            var user = usr.GetAllUsers();
            Assert.AreNotEqual(user.Where(t=>t.UserID ==userid).Count(),1);
        }

        [TestMethod]

        public void SearchUsersByName()
        {
            var users = usr.SearchUsersByName("varadha");
            Assert.AreEqual(users.Count,1);
        }

       /* [TestMethod]
        public void SortingUsers()
        {
            var users = usr.SortingUsers("FirstName");
            Assert.AreNotEqual(users.Count, 6);
        }*/

    }
}
