using com.GitHub.Reiqen.Task10_11.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.GitHub.Reiqen.Task10_11.DAL
{
    public interface IRolesDAO
    {
        IEnumerable<Role> GetRoles();
        void CreateRole(string title);
        void DeleteRole(int role_id);
        void UpdateRole(int role_id, string title);
    }
}
