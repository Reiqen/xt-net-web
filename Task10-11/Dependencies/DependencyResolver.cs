using com.GitHub.Reiqen.Task10_11.BLL;
using com.GitHub.Reiqen.Task10_11.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.GitHub.Reiqen.Task10_11.Dependencies
{
    public class DependencyResolver
    {
        private static IRolesDAO _rolesDAO;
        private static IRolesDAO _RolesDAO => _rolesDAO ?? (_rolesDAO = new RolesDAO());

        private static IRolesBL _rolesBL;
        public static IRolesBL RolesBL => _rolesBL ?? (_rolesBL = new RolesBL(_RolesDAO));

        private static IUsersDAO _usersDAO;
        private static IUsersDAO _UsersDAO => _usersDAO ?? (_usersDAO = new UsersDAO());

        private static IUsersBL _usersBL;
        public static IUsersBL UsersBL => _usersBL ?? (_usersBL = new UsersBL(_UsersDAO));

        private static IAwardsDAO _awardsDAO;
        private static IAwardsDAO _AwardsDAO => _awardsDAO ?? (_awardsDAO = new AwardsDAO());

        private static IAwardsBL _awardsBL;
        public static IAwardsBL AwardsBL => _awardsBL ?? (_awardsBL = new AwardsBL(_AwardsDAO));

        private static IPersonsDAO _personsDAO;
        private static IPersonsDAO _PersonsDAO => _personsDAO ?? (_personsDAO = new PersonsDAO());

        private static IPersonsBL _personsBL;
        public static IPersonsBL PersonsBL => _personsBL ?? (_personsBL = new PersonsBL(_PersonsDAO));
    }
}