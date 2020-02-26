using com.GitHub.Reiqen.Task10_11.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.GitHub.Reiqen.Task10_11.DAL
{
    public interface IUsersDAO
    {
        IEnumerable<User> GetUsers();
        void CreateUser(int role_id, string login, string password);
        void DeleteUser(int user_id);
        void UpdateUser(int user_id, int role_id, string login, string password);
    }
}
