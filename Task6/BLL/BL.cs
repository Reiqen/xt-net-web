using com.GitHub.Reiqen.Task6.DAL;
using com.GitHub.Reiqen.Task6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.GitHub.Reiqen.Task6.BLL
{
    public class BL : IUserBL
    {
        private readonly IUserDao _userDao;

        public BL(IUserDao userDao)
        {
            _userDao = userDao;
        }
        public IEnumerable<User> GetUsers()
        {
            return _userDao.GetUsers();
        }

        public void AddUser(string name, DateTime dateOfBirth, IEnumerable<string> titles)
        {
            _userDao.AddUser(name, dateOfBirth, titles);
        }

        public void DeleteUser(int id)
        {
            try
            {
                _userDao.DeleteUser(id);
            }
            catch(ArgumentException ar)
            {
                Console.WriteLine("No user found with this ID.");
            }
        }

        public void AddAwardToUser(int id, IEnumerable<string> titles)
        {
            try
            {
                _userDao.AddAwardToUser(id, titles);
            }
            catch (ArgumentException ar)
            {
                Console.WriteLine("No user found with this ID.");
            }
        }
    }
}
