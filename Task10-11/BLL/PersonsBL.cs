using com.GitHub.Reiqen.Task10_11.DAL;
using com.GitHub.Reiqen.Task10_11.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.GitHub.Reiqen.Task10_11.BLL
{
    public class PersonsBL : IPersonsBL
    {
        private readonly IPersonsDAO _personsDao;

        public PersonsBL(IPersonsDAO personsDao)
        {
            _personsDao = personsDao;
        }
        public void AddAward(int person_id, int award_id)
        {
            _personsDao.AddAward(person_id, award_id);
        }

        public void CreatePerson(string name, DateTime dateOfBirth, byte[] image)
        {
            _personsDao.CreatePerson(name, dateOfBirth, image);
        }

        public void DeletePerson(int person_id)
        {
            _personsDao.DeletePerson(person_id);
        }

        public IEnumerable<Person> GetPersons()
        {
            return _personsDao.GetPersons();
        }

        public void RemoveAward(int person_id, int award_id)
        {
            _personsDao.RemoveAward(person_id, award_id);
        }

        public void UpdatePerson(int person_id, string name, DateTime dateOfBirth, byte[] image)
        {
            _personsDao.UpdatePerson(person_id, name, dateOfBirth, image);
        }
    }
}