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
    public class UsersController : ApiController
    {
        private UsersBusiness UserBL = new UsersBusiness();
        // GET: api/Users
        [HttpGet]
        public IList<UserEntity> GetAllUsers()
        {
            return UserBL.GetAllUsers();
        }

        // GET: api/Users/5
        [HttpGet]
        public UserEntity GetUserDetails(int id)
        {
            return UserBL.GetUserDetails(id);
        }

        // POST: api/Users
        [HttpPost]
        public void SaveUser(UserEntity value)
        {
            UserBL.SaveUserDetails(value);
        }

        // PUT: api/Users/5
        [HttpPut]
        public void UpdateUser(UserEntity value)
        {
            UserBL.UpdateUserDetail(value.UserID, value);
        }

        [HttpDelete]
        // DELETE: api/Users/5
        public void DeleteUser(int id)
        {
            UserBL.DeleteUser(id);
        }

        [HttpGet]

        public List<UserEntity> SearchUsersByName(string name)
        {
            return UserBL.SerchUsersbyName(name);
        }

        [HttpGet]
        public List<UserEntity> SortingUsers(string columnName)
        {
            return UserBL.SortingUsers(columnName);
        }

    }
}
