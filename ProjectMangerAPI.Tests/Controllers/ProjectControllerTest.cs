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
   public class ProjectControllerTest
    {
        ProjectController prj = new ProjectController();
      /*  [TestMethod]
        public void GetAllProjects_test()
        {
            var projs = prj.GetAllProjects();
            Assert.AreNotEqual(projs.Count(), 5);
        }

        [TestMethod]
        public void Getprojectdetails_test()
        {
            var proj = prj.GetprojectDetails(1);
            Assert.AreEqual(proj.ProjectName, "Project1");
        }

        [TestMethod]
        public void DeleteUser()
        {
            int prjId = 1005;
            prj.DeleteProject(prjId);
            var prjs = prj.GetAllProjects();
            Assert.AreNotEqual(prjs.Where(t => t.ProjectID == prjId).Count(), 1);
        }

        [TestMethod]
        public void SearchUsersByName()
        {
            var users = prj.SearchProjects("Project1");
            Assert.AreEqual(users.Count, 1);
        }

        [TestMethod]
        public void SortingUsers()
        {
            var prjs = prj.SortingProjects("StartDate");
            Assert.AreNotEqual(prjs.Count, 6);
        }*/
    }
}
