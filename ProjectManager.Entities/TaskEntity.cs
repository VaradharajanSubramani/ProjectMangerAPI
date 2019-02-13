using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Entities
{
    public class TaskEntity
    {      
        public TaskEntity()
        {
            ParentTask = new ParentTaskEntity();
            Project = new ProjectEntity();
            Users = new List<UserEntity>();
        }
           
        public int TaskID { get; set; }
        public int ParentID { get; set; }
        public int ProjectID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }
        public int UserID { get; set; }

        public ParentTaskEntity ParentTask { get; set; }
        public ProjectEntity Project { get; set; }
        public List<UserEntity> Users { get; set; }

    
    }
}
