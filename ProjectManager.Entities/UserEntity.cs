using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Entities
{
    public class UserEntity
    {
        public UserEntity()
        {
            Project = new ProjectEntity();
            Task = new TaskEntity();
        }

        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeeID { get; set; }
        public int ProjectID { get; set; }
        public int TaskID { get; set; }

        public virtual ProjectEntity Project { get; set; }
        public virtual TaskEntity Task { get; set; }
    }
}
