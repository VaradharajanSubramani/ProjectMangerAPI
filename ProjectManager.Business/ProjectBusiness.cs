using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Repository;
using ProjectManager.Entities;

namespace ProjectManager.Business
{
   public class ProjectBusiness
    {
        private ProjectRepository ProjRep = new ProjectRepository();
        private MapHelper Map = new MapHelper();

        public List<ProjectEntity> GetAllProjects()
        {
            var projs = ProjRep.GetAllProjects();
            List<ProjectEntity> projEntityList = new List<ProjectEntity>();

            foreach(Project proj in projs)
            {
                var projEntity = Map.ConvertProjectModeltoEntity(proj);
                if (proj.Tasks != null)
                {
                    projEntity.NoOfTasks = proj.Tasks.Count;
                    projEntity.CompletedTasks = proj.Tasks.Where(s => s.Status == "Completed").ToList().Count;
                }               

                projEntityList.Add(projEntity);
            }
            return projEntityList;
        }

        public ProjectEntity GetProjDetails(int id)
        {
            var proj = ProjRep.GetProjDetail(id);

            var prjEntity = Map.ConvertProjectModeltoEntity(proj);
            prjEntity.UserID = proj.Users.FirstOrDefault().User_ID;

            return prjEntity;
        }

        public int SaveProjDetails(ProjectEntity projEn)
        {
            Project proj = Map.ConvertProjectEntitytoModel(projEn);
            var projid = ProjRep.SaveProjDetails(proj);
            return ProjRep.UpdateProjectIDintoUser(projEn.UserID, projid);

        }

        public int UpdateProjDetails(int id, ProjectEntity projEn)
        {
            Project proj = Map.ConvertProjectEntitytoModel(projEn);
            return ProjRep.UpdateProjDetails(id, proj);
        }

        public void DeleteProj (int id)
        {
            ProjRep.DeleteProj(id);
        }

        public List<ProjectEntity> SerchProjbyName(string name)
        {
            var projs = ProjRep.SerchProjbyName(name);
            List<ProjectEntity> projEntityList = new List<ProjectEntity>();

            foreach (Project proj in projs)
            {
                var projEntity = Map.ConvertProjectModeltoEntity(proj);
                if (proj.Tasks != null)
                {
                    projEntity.NoOfTasks = proj.Tasks.Count;
                    projEntity.CompletedTasks = proj.Tasks.Where(s => s.Status == "Completed").ToList().Count;
                }
                projEntityList.Add(projEntity);
            }
            return projEntityList;

        }

        public List<ProjectEntity> SortingProject(string columnName)
        {
            var projs = ProjRep.SortingProj(columnName);
            List<ProjectEntity> projEntityList = new List<ProjectEntity>();

            foreach (Project proj in projs)
            {
                var projEntity = Map.ConvertProjectModeltoEntity(proj);
                if (proj.Tasks != null)
                {
                    projEntity.NoOfTasks = proj.Tasks.Count;
                    projEntity.CompletedTasks = proj.Tasks.Where(s => s.Status == "Completed").ToList().Count;
                }

                projEntityList.Add(projEntity);
            }
            return projEntityList;
        }
    }
}
