using com.GitHub.Reiqen.Task6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.GitHub.Reiqen.Task6.DAL
{
    public interface IUserDao
    {
        IEnumerable<User> GetUsers();
        void AddUser(string name, DateTime dateOfBirth, IEnumerable<string> titles);
        void DeleteUser(int id);
        void AddAwardToUser(int id, IEnumerable<string> titles);
    }
}
