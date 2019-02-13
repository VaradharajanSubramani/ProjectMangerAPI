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
    public class TasksController : ApiController
    {
        private TasksBusiness TaskBL = new TasksBusiness();
        // GET: api/Tasks
        [HttpGet]
        public IList<TaskEntity> GetAllTasks()
        {
            return  TaskBL.GetAllTasks();
        }
        [HttpGet]
        public IList<ParentTaskEntity> GetAllParentTasks()
        {
            return TaskBL.GetAllParentTasks();
        }
        [HttpGet]
        // GET: api/Tasks/5
        public TaskEntity GetTaskDetails(int id)
        {
            return TaskBL.GetTaskDetails(id);
        }
        [HttpPost]
        // POST: api/Tasks
        public void SaveTask(TaskEntity value)
        {
            TaskBL.SaveTask(value);
        }

        // PUT: api/Tasks/5
        [HttpPut]
        public void UpdateTask(TaskEntity value)
        {
            TaskBL.UpdateTask(value.TaskID, value);
        }

        [HttpDelete]
        // DELETE: api/Tasks/5
        public void Delete(int id)
        {
            TaskBL.DeleteTask(id);
        }

        [HttpPost]
        public void CompleteTask(int id)
        {
            TaskBL.EndTask(id);
        }

        [HttpGet]
        public List<TaskEntity> SortingTask(string columnName)
        {
           return TaskBL.SortingTasks(columnName);
        }
        [HttpGet]
        public List<TaskEntity> SearchTasks(string name)
        {
            return TaskBL.SearchTasks(name);
        }
    }
}
