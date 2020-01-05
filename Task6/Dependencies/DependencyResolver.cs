using com.GitHub.Reiqen.Task6.BLL;
using com.GitHub.Reiqen.Task6.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.GitHub.Reiqen.Task6.Dependencies
{
    public static class DependencyResolver
    {
        private static IUserDao _userDao;
        private static IUserDao _UserDao => _userDao ?? (_userDao = new UsersDAO());

        private static IUserBL _userBL;
        public static IUserBL UserBL => _userBL ?? (_userBL = new BL(_UserDao));
    }
}
