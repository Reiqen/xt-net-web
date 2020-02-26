using com.GitHub.Reiqen.Task10_11.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;

namespace com.GitHub.Reiqen.Task10_11.DAL
{
    public class AwardsDAO : IAwardsDAO
    {
        private string _sqlConnection = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        private SqlDataReader _dataReader;
        private List<Award> awards;

        public void CreateAward(string title, byte[] image)
        {
            using (SqlConnection con = new SqlConnection(_sqlConnection))
            {
                using (SqlCommand cmd = new SqlCommand("CreateAward", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = title;
                    cmd.Parameters.Add("@Image", SqlDbType.Image).Value = image;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAward(int award_id)
        {
            using (SqlConnection con = new SqlConnection(_sqlConnection))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteAward", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Award_id", SqlDbType.Int).Value = award_id;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Award> GetAwards()
        {
            awards = new List<Award>();
            using (SqlConnection con = new SqlConnection(_sqlConnection))
            {
                using (SqlCommand cmd = new SqlCommand("SelectAwards", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    cmd.ExecuteNonQuery();

                    _dataReader = cmd.ExecuteReader();
                    while (_dataReader.Read())
                    {
                        Award award = new Award();
                        award.award_id = int.Parse(_dataReader.GetValue(0).ToString());
                        award.title = _dataReader.GetValue(1).ToString();
                        byte[] byteArray;
                        if (_dataReader.GetValue(2) != DBNull.Value)
                        {
                            byteArray = new byte[((byte[])_dataReader.GetValue(2)).Length];
                            byteArray = (byte[])_dataReader.GetValue(2);
                        }
                        else
                        {
                            byteArray = null;
                        }
                        award.image = byteArray;

                        awards.Add(award);
                    }
                    return awards;
                }
            }
        }

        public void UpdateAward(int award_id, string title, byte[] image)
        {
            using (SqlConnection con = new SqlConnection(_sqlConnection))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateAward", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Award_id", SqlDbType.Int).Value = award_id;
                    cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;
                    cmd.Parameters.Add("@Image", SqlDbType.Image).Value = image;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}