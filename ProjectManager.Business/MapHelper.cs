using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Repository;
using ProjectManager.Entities;

namespace ProjectManager.Business
{
    public class MapHelper
    {
        public TaskEntity ConvertTaskModeltoEntity(Repository.Task task)
        {
            TaskEntity taskEntity = new TaskEntity();
            taskEntity.TaskID = task.Task_ID;
            taskEntity.TaskName = task.Task1;
            taskEntity.ProjectID = task.Project_ID ?? 0;
            taskEntity.ParentID = task.Parent_ID;
            taskEntity.Priority = task.Priority ?? 0;
            taskEntity.StartDate = task.Start_Date ?? DateTime.Now;
            taskEntity.EndDate = task.End_Date ?? DateTime.Now;
            taskEntity.Status = task.Status;

            //taskEntity.Project = ConvertProjectModeltoEntity(task.Project);
            //taskEntity.ParentTask = ConvertTaskParentModeltoEntity(task.ParentTask);
            //if (task.Users != null && task.Users.Count > 0)
            //{
            //    foreach (User user in task.Users)
            //    {
            //        taskEntity.Users.Add(ConvertUserModeltoEntity(user));
            //    }
            //}
            return taskEntity;
        }

        public Repository.Task ConvertTaskEntitytoModel(TaskEntity taskEntity)
        {
            Repository.Task task = new Repository.Task();

            task.Task_ID = taskEntity.TaskID;
            task.Task1 = taskEntity.TaskName;
            task.Project_ID = taskEntity.ProjectID;
            task.Parent_ID = taskEntity.ParentID;
            task.Priority = taskEntity.Priority;
            task.Start_Date = taskEntity.StartDate;
            task.End_Date = taskEntity.EndDate;
            task.Status = taskEntity.Status;

            //task.Project = ConvertProjectEntitytoModel(taskEntity.Project);
            //task.ParentTask = ConvertTaskParentEntitytoModel(taskEntity.ParentTask);
            //if (taskEntity.Users != null && taskEntity.Users.Count > 0)
            //{
            //    foreach (UserEntity user in taskEntity.Users)
            //    {
            //        task.Users.Add(ConvertUserEntitytoModel(user));
            //    }
            //}

            return task;

        }

        public ParentTaskEntity ConvertTaskParentModeltoEntity(ParentTask ptask)
        {
            ParentTaskEntity ptaskEntity = new ParentTaskEntity();
            ptaskEntity.ParentId = ptask.Parent_ID;
            ptaskEntity.ParentTaskName = ptask.Parent_Task;
            return ptaskEntity;
        }

        public ParentTask ConvertTaskParentEntitytoModel(ParentTaskEntity ptaskEntity)
        {
            ParentTask ptask = new ParentTask();
            ptask.Parent_ID = ptaskEntity.ParentId;
            ptask.Parent_Task = ptaskEntity.ParentTaskName;
            return ptask;
        }

        public ProjectEntity ConvertProjectModeltoEntity(Project proj)
        {
            ProjectEntity projEntity = new ProjectEntity();
            projEntity.ProjectID = proj.Project_ID;
            projEntity.ProjectName = proj.Project1;
            projEntity.StartDate = proj.Start_Date ?? DateTime.Now;
            projEntity.EndDate = proj.End_Date ?? DateTime.Now;
            projEntity.Priority = proj.Priority ?? 0;

            //if (proj.Tasks != null && proj.Tasks.Count > 0)
            //{
            //    foreach (Repository.Task task in proj.Tasks)
            //    {
            //        projEntity.Tasks.Add(ConvertTaskModeltoEntity(task));
            //    }
            //}
            //if (proj.Users != null && proj.Users.Count > 0)
            //{
            //    foreach (User user in proj.Users)
            //    {
            //        projEntity.Users.Add(ConvertUserModeltoEntity(user));
            //    }
            //}

            return projEntity;
        }

        public Project ConvertProjectEntitytoModel(ProjectEntity projEntity)
        {
            Project proj = new Project();

            proj.Project_ID = projEntity.ProjectID;
            proj.Project1 = projEntity.ProjectName;
            proj.Start_Date = projEntity.StartDate;
            proj.End_Date = projEntity.EndDate;
            proj.Priority = projEntity.Priority;

            //if (projEntity.Tasks != null && projEntity.Tasks.Count > 0)
            //{
            //    foreach (TaskEntity task in projEntity.Tasks)
            //    {
            //        proj.Tasks.Add(ConvertTaskEntitytoModel(task));
            //    }
            //}
            //if (projEntity.Users != null && projEntity.Users.Count > 0)
            //{
            //    foreach (UserEntity user in projEntity.Users)
            //    {
            //        proj.Users.Add(ConvertUserEntitytoModel(user));
            //    }
            //}

            return proj;
        }

        public UserEntity ConvertUserModeltoEntity(User user)
        {
            UserEntity userEntity = new UserEntity();
            userEntity.UserID = user.User_ID;
            userEntity.ProjectID = user.Project_ID;
            userEntity.TaskID = user.Task_ID??0;
            userEntity.FirstName = user.FirstName;
            userEntity.Lastname = user.Lastname;
            userEntity.EmployeeID = user.Employee_ID??0;

            //if (user.Project != null)
            //    userEntity.Project = ConvertProjectModeltoEntity(user.Project);

            //if (user.Task != null)
            //    userEntity.Task = ConvertTaskModeltoEntity(user.Task);
            return userEntity;
        }

        public User ConvertUserEntitytoModel(UserEntity userEntity)
        {
            User user = new User();
            user.User_ID = userEntity.UserID;
            user.Project_ID = userEntity.ProjectID;
            user.Task_ID = userEntity.TaskID;
            user.FirstName = userEntity.FirstName;
            user.Lastname = userEntity.Lastname;
            user.Employee_ID = userEntity.EmployeeID;

            //if (userEntity.Project != null)
            //    user.Project = ConvertProjectEntitytoModel(userEntity.Project);
            //if (userEntity.Task != null)
            //    user.Task = ConvertTaskEntitytoModel(userEntity.Task);

            return user;
        }
    }
}
