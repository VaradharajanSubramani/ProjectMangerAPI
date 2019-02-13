using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManager.Business;
using ProjectManager.Entities;

namespace ProjectMangerAPI.Controllers
{
    public class ProjectController : ApiController
    {
        private ProjectBusiness ProjBL = new ProjectBusiness();
        // GET: api/Project
        [HttpGet]
        public IList<ProjectEntity> GetAllProjects()
        {
            return ProjBL.GetAllProjects();
        }

        // GET: api/Project/5
        [HttpGet]
        public ProjectEntity GetprojectDetails(int id)
        {
            return ProjBL.GetProjDetails(id);
        }

        // POST: api/Project
        [HttpPost]
        public void SaveProject(ProjectEntity value)
        {
            ProjBL.SaveProjDetails(value);
        }

        // PUT: api/Project/5
        [HttpPut]
        public void UpdateProject(ProjectEntity value)
        {
            ProjBL.UpdateProjDetails(value.ProjectID, value);
        }

        // DELETE: api/Project/5
        [HttpDelete]
        public void DeleteProject(int id)
        {
            ProjBL.DeleteProj(id);
        }

        [HttpGet]
        public List<ProjectEntity> SortingProjects(string columnName)
        {
            return ProjBL.SortingProject(columnName);
        }

        [HttpGet]
        public List<ProjectEntity> SearchProjects(string name)
        {
            return ProjBL.SerchProjbyName(name);
        }
    }
}
