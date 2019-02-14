using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ProjectManager.Repository;
using ProjectManager.Entities;

namespace ProjectManager.Business
{
    public class TasksBusiness
    {

        private TasksRepositry TaskRep = new TasksRepositry();
        private MapHelper Map = new MapHelper();
        public List<TaskEntity> GetAllTasks()
        {
            List<Repository.Task> tasklist = TaskRep.GetAllTasks();

            List<TaskEntity> taskList = new List<TaskEntity>();
            foreach (Repository.Task item in tasklist)
            {
                var taskEntity = Map.ConvertTaskModeltoEntity(item);
                if (item.ParentTask != null)
                    taskEntity.ParentTask = Map.ConvertTaskParentModeltoEntity(item.ParentTask);
                if (item.Project != null)
                    taskEntity.Project = Map.ConvertProjectModeltoEntity(item.Project);                
                //if(item.Users !=null && item.Users.Count>0)
                //{
                //    foreach (User user in item.Users)
                //    {
                //        taskEntity.Users.Add(Map.ConvertUserModeltoEntity(user));
                //    }
                //}
                taskList.Add(taskEntity);
            }
            return taskList;
        }
        public TaskEntity GetTaskDetails(int id)
        {
            TaskEntity taskEntity = new TaskEntity();
            Repository.Task task = TaskRep.GetTaskDetail(id);
            if (task != null)
            {
                taskEntity = Map.ConvertTaskModeltoEntity(task);
                if (task.ParentTask != null)
                    taskEntity.ParentTask = Map.ConvertTaskParentModeltoEntity(task.ParentTask);
                if (task.Project != null)
                    taskEntity.Project = Map.ConvertProjectModeltoEntity(task.Project);
                if (task.Users != null)
                    taskEntity.UserID = task.Users.FirstOrDefault().User_ID;
            }
            return taskEntity;

        }


        public void SaveTask(TaskEntity value)
        {
            Repository.Task task = Map.ConvertTaskEntitytoModel(value);
            task.Parent_ID = task.Parent_ID == 0 ? 1 : task.Parent_ID;

            int taskid =  TaskRep.SaveTask(task);
            Thread.Sleep(5000);
            TaskRep.UpdateTaskinUser(taskid, value.UserID);
        }


        public void UpdateTask(int id, TaskEntity value)
        {
            Repository.Task task = Map.ConvertTaskEntitytoModel(value);
            TaskRep.UpdateTask(id, task);
        }
        public void DeleteTask(int id)
        {
            TaskRep.DeleteTask(id);
        }

        public void EndTask(int id)
        {
            TaskRep.EndTask(id);
            // return  StatusCode(HttpStatusCode.NoContent);
        }

        public List<ParentTaskEntity> GetAllParentTasks()
        {
            List<ParentTaskEntity> PTEntityList = new List<ParentTaskEntity>();
            List<ParentTask> PTList = TaskRep.GetAllParentTasks();

            if (PTList != null)
            {
                foreach (ParentTask pt in PTList)
                {
                    PTEntityList.Add(Map.ConvertTaskParentModeltoEntity(pt));
                }
            }
            return PTEntityList;
        }

        public List<TaskEntity> SortingTasks(string columnName)
        {
            var tasks = TaskRep.SortingTasks(columnName);

            List<TaskEntity> taskEntityList = new List<TaskEntity>();
            foreach (Repository.Task item in tasks)
            {
                var taskEntity = Map.ConvertTaskModeltoEntity(item);
                if (item.ParentTask != null)
                    taskEntity.ParentTask = Map.ConvertTaskParentModeltoEntity(item.ParentTask);
                if (item.Project != null)
                    taskEntity.Project = Map.ConvertProjectModeltoEntity(item.Project);

                taskEntityList.Add(taskEntity);
            }
            return taskEntityList;
        }
        public List<TaskEntity> SearchTasks(string name)
        {
            var tasks = TaskRep.SearchTasks(name);

            List<TaskEntity> taskEntityList = new List<TaskEntity>();
            foreach (Repository.Task item in tasks)
            {
                var taskEntity = Map.ConvertTaskModeltoEntity(item);
                if (item.ParentTask != null)
                    taskEntity.ParentTask = Map.ConvertTaskParentModeltoEntity(item.ParentTask);
                if (item.Project != null)
                    taskEntity.Project = Map.ConvertProjectModeltoEntity(item.Project);

                taskEntityList.Add(taskEntity);
            }
            return taskEntityList;
        }
    }
}
