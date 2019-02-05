using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Entities
{
    public class ProjectEntity
    {
        public ProjectEntity()
        {
            Tasks = new List<TaskEntity>();
            Users = new List<UserEntity>();
        }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public List<TaskEntity> Tasks { get; set; }
        public  List<UserEntity> Users { get; set; }
    }
}
