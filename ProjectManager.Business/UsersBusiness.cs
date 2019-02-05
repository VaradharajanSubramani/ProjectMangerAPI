using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Repository;
using ProjectManager.Entities;

namespace ProjectManager.Business
{
    public class UsersBusiness
    {
        private UserRepositry UserRepo = new UserRepositry();
        private MapHelper Map = new MapHelper();

        public List<UserEntity> GetAllUsers()
        {
            List<UserEntity> userlist = new List<UserEntity>();
            var users = UserRepo.GetAllUsers();

            foreach(User user in users)
            {
                UserEntity useren = Map.ConvertUserModeltoEntity(user);
                if (user.Project != null)
                    useren.Project = Map.ConvertProjectModeltoEntity(user.Project);
                if (user.Task != null)
                    useren.Task = Map.ConvertTaskModeltoEntity(user.Task);
                userlist.Add(useren);

            }
            return userlist;
        }

        public UserEntity GetUserDetails(int id)
        {
            try
            {
                var user = UserRepo.GetUserDetail(id);

                return Map.ConvertUserModeltoEntity(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int SaveUserDetails(UserEntity user)
        {
            try
            {
                if(user!=null)
                {
                    return UserRepo.SaveUsersDetails(Map.ConvertUserEntitytoModel(user));
                }
            }
            catch (Exception)
            {

                throw;
            }
            return 0;
        }

        public int UpdateUserDetail(int id,UserEntity user)
        {
            try
            {                
                return UserRepo.UpdateUserDetails(id, Map.ConvertUserEntitytoModel(user));
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
               return UserRepo.DeleteUser(id);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<UserEntity> SerchUsersbyName(string name)
        {
            try
            {
                var users = UserRepo.SerchUsersbyName(name);
                List<UserEntity> userlist = new List<UserEntity>();                
                foreach (User user in users)
                {
                    userlist.Add(Map.ConvertUserModeltoEntity(user));
                }
                return userlist;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<UserEntity> SortingUsers(string ColumnName)
        {
            try
            {
                var users = UserRepo.SortingUsers(ColumnName);
                List<UserEntity> userlist = new List<UserEntity>();
                foreach (User user in users)
                {
                    userlist.Add(Map.ConvertUserModeltoEntity(user));
                }
                return userlist;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
