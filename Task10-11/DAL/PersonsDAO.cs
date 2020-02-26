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
    public class PersonsDAO : IPersonsDAO
    {
        private string _sqlConnection = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        private SqlDataReader _dataReaderPersons;
        private SqlDataReader _dataReaderAwards;
        private List<Person> persons;
        private List<Award> awards;

        public void AddAward(int person_id, int award_id)
        {
            using (SqlConnection con = new SqlConnection(_sqlConnection))
            {
                using (SqlCommand cmd = new SqlCommand("CreateAwardsLinks", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Person_id", SqlDbType.Int).Value = person_id;
                    cmd.Parameters.Add("@Award_id", SqlDbType.Int).Value = award_id;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void CreatePerson(string name, DateTime dateOfBirth, byte[] image)
        {
            using (SqlConnection con = new SqlConnection(_sqlConnection))
            {
                using (SqlCommand cmd = new SqlCommand("CreatePerson", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
                    cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = dateOfBirth;
                    cmd.Parameters.Add("@Image", SqlDbType.Image).Value = image;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeletePerson(int person_id)
        {
            using (SqlConnection con = new SqlConnection(_sqlConnection))
            {
                using (SqlCommand cmd = new SqlCommand("DeletePerson", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Person_id", SqlDbType.Int).Value = person_id;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Person> GetPersons()
        {
            persons = new List<Person>();
            using (SqlConnection con = new SqlConnection(_sqlConnection))
            {
                using (SqlCommand cmd = new SqlCommand("SelectPersons", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    cmd.ExecuteNonQuery();

                    _dataReaderPersons = cmd.ExecuteReader();
                    while (_dataReaderPersons.Read())
                    {
                        Person person = new Person();
                        awards = new List<Award>();
                        person.person_id = int.Parse(_dataReaderPersons.GetValue(0).ToString());
                        person.name = _dataReaderPersons.GetValue(1).ToString();
                        person.dateOfBirth = DateTime.Parse(_dataReaderPersons.GetValue(2).ToString());
                        var today = DateTime.Today;
                        var age = today.Year - person.dateOfBirth.Year;
                        if (person.dateOfBirth.Date > today.AddYears(-age)) age--;
                        person.age = age;
                        byte[] byteArray;
                        if (_dataReaderPersons.GetValue(3) != DBNull.Value)
                        {
                            byteArray = new byte[((byte[])_dataReaderPersons.GetValue(3)).Length];
                            byteArray = (byte[])_dataReaderPersons.GetValue(3);
                        }
                        else
                        {
                            byteArray = null;
                        }
                        person.image = byteArray;
                        using (SqlCommand cmd2 = new SqlCommand("SelectAwardsLinks", con))
                        {
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Add("@Person_id", SqlDbType.Int).Value = person.person_id;
                            cmd2.ExecuteNonQuery();

                            _dataReaderAwards = cmd2.ExecuteReader();
                            while (_dataReaderAwards.Read())
                            {
                                Award award = new Award();
                                award.award_id = int.Parse(_dataReaderAwards.GetValue(0).ToString());
                                award.title = _dataReaderAwards.GetValue(1).ToString();
                                awards.Add(award);
                            }
                        }
                        person.awards = awards;
                        persons.Add(person);
                    }  
                }
                return persons;
            }
        }

        public void RemoveAward(int person_id, int award_id)
        {
            using (SqlConnection con = new SqlConnection(_sqlConnection))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteAwardsLinks", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Person_id", SqlDbType.Int).Value = person_id;
                    cmd.Parameters.Add("@Award_id", SqlDbType.Int).Value = award_id;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePerson(int person_id, string name, DateTime dateOfBirth, byte[] image)
        {
            using (SqlConnection con = new SqlConnection(_sqlConnection))
            {
                using (SqlCommand cmd = new SqlCommand("UpdatePerson", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Person_id", SqlDbType.Int).Value = person_id;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
                    cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = dateOfBirth;
                    cmd.Parameters.Add("@Image", SqlDbType.Image).Value = image;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}