using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Repository
{
    public class TasksRepositry
    {
        private ProjectManagerEntities PMEntitites = new ProjectManagerEntities();

        public List<Task> GetAllTasks()
        {
            try
            {
                List<Task> tasklist = PMEntitites.Tasks.ToList();

                return tasklist;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int SaveTask(Task taskdetails)
        {
            try
            {
                if (taskdetails != null)
                {
                    taskdetails.Status = "InProgress";
                    PMEntitites.Tasks.Add(taskdetails);
                    PMEntitites.SaveChanges();
                    return taskdetails.Task_ID;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return 0;
        }

        public int UpdateTask(int taskid, Task taskdetails)
        {
            try
            {
                if (taskdetails != null)
                {
                    if (taskdetails.Task_ID != 0)
                    {
                        Task t = PMEntitites.Tasks.Where(x => x.Task_ID == taskid).FirstOrDefault();
                        if (t != null)
                        {
                            t.Task1 = taskdetails.Task1;
                            t.Parent_ID = taskdetails.Parent_ID;
                            t.Priority = taskdetails.Priority;
                            t.Start_Date = taskdetails.Start_Date;
                            t.End_Date = taskdetails.End_Date;
                            t.Project_ID = taskdetails.Project_ID;
                            
                            PMEntitites.Tasks.Add(t);
                            PMEntitites.Entry(t).State = System.Data.Entity.EntityState.Modified;
                            return PMEntitites.SaveChanges();
                        }

                    }
                    return PMEntitites.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }

        public void DeleteTask(int taskid)
        {
            try
            {
                if (taskid != 0)
                {
                    Task t = PMEntitites.Tasks.Where(x => x.Task_ID == taskid).FirstOrDefault();
                    PMEntitites.Tasks.Remove(t);
                    PMEntitites.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int EndTask(int taskid)
        {
            try
            {
                if (taskid != 0)
                {
                    Task t = PMEntitites.Tasks.Where(x => x.Task_ID == taskid).FirstOrDefault();
                    t.Status = "Completed";
                    return PMEntitites.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return 0;
        }

        public Task GetTaskDetail(int taskid)
        {
            try
            {
                if (taskid != 0)
                {
                    Task t = PMEntitites.Tasks.Where(x => x.Task_ID == taskid).FirstOrDefault();
                    return t;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        public List<ParentTask> GetAllParentTasks()
        {
            try
            {
                List<ParentTask> ptasklist = PMEntitites.ParentTasks.ToList();

                return ptasklist;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Task> SortingTasks(string columnName)
        {
            try
            {
                switch (columnName)
                {
                    case "StartDate":
                        return PMEntitites.Tasks.OrderBy(x => x.Start_Date).ToList();
                    case "EndDate":
                        return PMEntitites.Tasks.OrderBy(x => x.End_Date).ToList();
                    case "Priority":
                        return PMEntitites.Tasks.OrderBy(x => x.Priority).ToList();
                    case "Completed":
                        return PMEntitites.Tasks.OrderBy(x => x.Status).ToList();
                    default:
                        return PMEntitites.Tasks.ToList();

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Task> SearchTasks(string name)
        {
            try
            {
                List<Task> projs = new List<Task>();
                if (!string.IsNullOrEmpty(name))
                {
                    projs = PMEntitites.Tasks.Where(x => x.Task1.Contains(name)).ToList();

                }
                else
                {
                    projs = PMEntitites.Tasks.ToList();
                }
                return projs;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int UpdateTaskinUser(int taskid,int userid)
        {
            try
            {
                if (taskid != 0)
                {
                    User usr = PMEntitites.Users.Where(x => x.User_ID == userid).FirstOrDefault();
                    usr.Task_ID = taskid;
                    PMEntitites.Users.Add(usr);
                    PMEntitites.Entry(usr).State = System.Data.Entity.EntityState.Modified;


                    return PMEntitites.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }
    }
}
