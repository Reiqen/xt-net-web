using com.GitHub.Reiqen.Task10_11.DAL;
using com.GitHub.Reiqen.Task10_11.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.GitHub.Reiqen.Task10_11.BLL
{
    public class RolesBL : IRolesBL
    {
        private readonly IRolesDAO _rolesDao;

        public RolesBL(IRolesDAO rolesDao)
        {
            _rolesDao = rolesDao;
        }

        public void CreateRole(string title)
        {
            _rolesDao.CreateRole(title);
        }

        public void DeleteRole(int role_id)
        {
            _rolesDao.DeleteRole(role_id);
        }

        public IEnumerable<Role> GetRoles()
        {
            return _rolesDao.GetRoles();
        }

        public void UpdateRole(int role_id, string title)
        {
            _rolesDao.UpdateRole(role_id, title);
        }
    }
}