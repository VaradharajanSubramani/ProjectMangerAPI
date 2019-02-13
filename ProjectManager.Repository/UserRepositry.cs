using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Repository
{
    public class UserRepositry
    {
        private ProjectManagerEntities PMEntitites = new ProjectManagerEntities();

        public List<User> GetAllUsers()
        {
            try
            {
                List<User> userlist = PMEntitites.Users.ToList();

                return userlist;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int SaveUsersDetails(User userdetails)
        {
            try
            {
                if (userdetails != null)
                {
                    if (userdetails.Task_ID == 0)
                        userdetails.Task_ID = null;
                    if (userdetails.Project_ID == 0)
                        userdetails.Project_ID = null;

                    PMEntitites.Users.Add(userdetails);
                    return PMEntitites.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }

        public User GetUserDetail(int id)
        {
            try
            {
                if (id != 0)
                {
                    var user = PMEntitites.Users.Where(x => x.User_ID == id).FirstOrDefault();
                    return user;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        public int UpdateUserDetails(int id, User userdetails)
        {
            try
            {
                var user = PMEntitites.Users.Where(x => x.User_ID == id).FirstOrDefault();

                user.Employee_ID = userdetails.Employee_ID;
                user.FirstName = userdetails.FirstName;
                user.LastName = userdetails.LastName;
               // user.Project_ID = userdetails.Project_ID;
                //user.Task_ID = userdetails.Task_ID;

                PMEntitites.Users.Add(user);
                PMEntitites.Entry(user).State = System.Data.Entity.EntityState.Modified;
                return PMEntitites.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }

        }

        public int DeleteUser(int id)
        {
            try
            {
                var user = PMEntitites.Users.Where(x => x.User_ID == id).FirstOrDefault();
                PMEntitites.Users.Remove(user);
                return PMEntitites.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<User> SortingUsers(string columnName)
        {
            try
            {
                switch (columnName)
                {
                    case "FirstName":
                        return PMEntitites.Users.OrderBy(x => x.FirstName).ToList();
                    case "LastName":
                        return PMEntitites.Users.OrderBy(x => x.LastName).ToList();
                    case "EmployeeId":
                        return PMEntitites.Users.OrderBy(x => x.Employee_ID).ToList();
                    default:
                        return PMEntitites.Users.ToList();

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<User> SerchUsersbyName(string name)
        {
            try
            {
                List<User> users = new List<User>();
                if (!string.IsNullOrEmpty(name))
                {
                     users = PMEntitites.Users.Where(x => x.FirstName.Contains(name) || x.LastName.Contains(name)).ToList();
                   
                }
                else
                {
                     users = PMEntitites.Users.ToList();
                }
                return users;
            }
            catch (Exception)
            {
                throw;
            }            
        }

    }
}
