using com.GitHub.Reiqen.Task10_11.DAL;
using com.GitHub.Reiqen.Task10_11.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.GitHub.Reiqen.Task10_11.BLL
{
    public class UsersBL : IUsersBL
    {
        private readonly IUsersDAO _usersDao;

        public UsersBL(IUsersDAO usersDao)
        {
            _usersDao = usersDao;
        }
        public void CreateUser(int role_id, string login, string password)
        {
            _usersDao.CreateUser(role_id, login, password);
        }

        public void DeleteUser(int user_id)
        {
            _usersDao.DeleteUser(user_id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _usersDao.GetUsers();
        }

        public void UpdateUser(int user_id, int role_id, string login, string password)
        {
            _usersDao.UpdateUser(user_id, role_id, login, password);
        }
    }
}