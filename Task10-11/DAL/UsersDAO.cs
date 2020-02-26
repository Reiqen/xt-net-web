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
    public class UsersDAO : IUsersDAO
    {
        private string _sqlConnection = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        private SqlDataReader _dataReader;
        private List<User> users;
        public void CreateUser(int role_id, string login, string password)
        {
            using (SqlConnection con = new SqlConnection(_sqlConnection))
            {
                using (SqlCommand cmd = new SqlCommand("CreateUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Role_id", SqlDbType.Int).Value = role_id;
                    cmd.Parameters.Add("@Login", SqlDbType.VarChar).Value = login;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUser(int user_id)
        {
            using (SqlConnection con = new SqlConnection(_sqlConnection))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@User_id", SqlDbType.Int).Value = user_id;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<User> GetUsers()
        {
            users = new List<User>();
            using (SqlConnection con = new SqlConnection(_sqlConnection))
            {
                using (SqlCommand cmd = new SqlCommand("SelectUsers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    cmd.ExecuteNonQuery();

                    _dataReader = cmd.ExecuteReader();
                    while (_dataReader.Read())
                    {
                        User user = new User();
                        user.user_id = int.Parse(_dataReader.GetValue(0).ToString());
                        user.role_id = int.Parse(_dataReader.GetValue(1).ToString());
                        user.role = _dataReader.GetValue(2).ToString();
                        user.login = _dataReader.GetValue(3).ToString();
                        user.password = _dataReader.GetValue(4).ToString();
                        users.Add(user);
                    }
                    return users;
                }
            }
        }

        public void UpdateUser(int user_id, int role_id, string login, string password)
        {
            using (SqlConnection con = new SqlConnection(_sqlConnection))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@User_id", SqlDbType.Int).Value = user_id;
                    cmd.Parameters.Add("@Role_id", SqlDbType.Int).Value = role_id;
                    cmd.Parameters.Add("@Login", SqlDbType.VarChar).Value = login;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}