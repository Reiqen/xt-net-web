using com.GitHub.Reiqen.Task10_11.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace com.GitHub.Reiqen.Task10_11.DAL
{
    public class RolesDAO : IRolesDAO
    {
        private string _sqlConnection = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        private SqlDataReader _dataReader;
        private List<Role> roles;


        public void CreateRole(string title)
        {
            using (SqlConnection con = new SqlConnection(_sqlConnection))
            {
                using (SqlCommand cmd = new SqlCommand("CreateRole", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Value", SqlDbType.VarChar).Value = title;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteRole(int role_id)
        {
            using (SqlConnection con = new SqlConnection(_sqlConnection))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteRole", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Role_id", SqlDbType.Int).Value = role_id;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Role> GetRoles()
        {
            roles = new List<Role>();
            using (SqlConnection con = new SqlConnection(_sqlConnection))
            {
                using (SqlCommand cmd = new SqlCommand("SelectRoles", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    cmd.ExecuteNonQuery();

                    _dataReader = cmd.ExecuteReader();
                    while (_dataReader.Read())
                    {
                        Role role = new Role();
                        role.role_id = int.Parse(_dataReader.GetValue(0).ToString());
                        role.title = _dataReader.GetValue(1).ToString();
                        roles.Add(role);
                    }
                    return roles;
                }
            }
        }

        public void UpdateRole(int role_id, string title)
        {
            using (SqlConnection con = new SqlConnection(_sqlConnection))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateRole", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Role_id", SqlDbType.Int).Value = role_id;
                    cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = title;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}