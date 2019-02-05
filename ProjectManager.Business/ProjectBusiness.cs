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
            List<ProjectEntity> projEntity = new List<ProjectEntity>();

            foreach(Project proj in projs)
            {
                projEntity.Add(Map.ConvertProjectModeltoEntity(proj));
            }
            return projEntity;
        }

        public ProjectEntity GetProjDetails(int id)
        {
            var proj = ProjRep.GetProjDetail(id);
            return Map.ConvertProjectModeltoEntity(proj);
        }

        public int SaveProjDetails(ProjectEntity projEn)
        {
            Project proj = Map.ConvertProjectEntitytoModel(projEn);
            return ProjRep.SaveProjDetails(proj);
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
            List<ProjectEntity> projEntity = new List<ProjectEntity>();

            foreach (Project proj in projs)
            {
                projEntity.Add(Map.ConvertProjectModeltoEntity(proj));
            }
            return projEntity;

        }

        public List<ProjectEntity> SortingProject(string columnName)
        {
            var projs = ProjRep.SortingProj(columnName);
            List<ProjectEntity> projEntity = new List<ProjectEntity>();

            foreach (Project proj in projs)
            {
                projEntity.Add(Map.ConvertProjectModeltoEntity(proj));
            }
            return projEntity;
        }
    }
}
