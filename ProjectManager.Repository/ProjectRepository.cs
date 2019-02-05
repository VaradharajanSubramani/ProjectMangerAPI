using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Repository
{
    public class ProjectRepository
    {
        private ProjectManagerEntities PMEntitites = new ProjectManagerEntities();

        public List<Project> GetAllProjects()
        {
            try
            {
                List<Project> projlist = PMEntitites.Projects.ToList();

                return projlist;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int SaveProjDetails(Project projdetails)
        {
            try
            {
                if (projdetails != null)
                {
                    PMEntitites.Projects.Add(projdetails);
                    return PMEntitites.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }

        public Project GetProjDetail(int id)
        {
            try
            {
                if (id != 0)
                {
                    var proj = PMEntitites.Projects.Where(x => x.Project_ID == id).FirstOrDefault();
                    return proj;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        public int UpdateProjDetails(int id, Project projDetails)
        {
            try
            {
                var proj = PMEntitites.Projects.Where(x => x.Project_ID == id).FirstOrDefault();

                proj.Project1 = projDetails.Project1;
                proj.Start_Date = projDetails.Start_Date;
                proj.End_Date = projDetails.End_Date;
                proj.Priority = projDetails.Priority;

                PMEntitites.Projects.Add(proj);
                PMEntitites.Entry(proj).State = System.Data.Entity.EntityState.Modified;
                return PMEntitites.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }

        }

        public int DeleteProj(int id)
        {
            try
            {
                var proj = PMEntitites.Projects.Where(x => x.Project_ID == id).FirstOrDefault();
                PMEntitites.Projects.Remove(proj);
                return PMEntitites.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Project> SortingProj(string columnName)
        {
            try
            {
                switch (columnName)
                {
                    case "StartDate":
                        return PMEntitites.Projects.OrderBy(x => x.Start_Date).ToList();
                    case "EndDate":
                        return PMEntitites.Projects.OrderBy(x => x.End_Date).ToList();
                    case "Priority":
                        return PMEntitites.Projects.OrderBy(x => x.Priority).ToList();                    
                    default:
                        return PMEntitites.Projects.ToList();

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Project> SerchProjbyName(string name)
        {
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    var projs = PMEntitites.Projects.Where(x => x.Project1.Contains(name)).ToList();
                    return projs;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }
    }
}
