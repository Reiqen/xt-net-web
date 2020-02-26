using com.GitHub.Reiqen.Task10_11.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.GitHub.Reiqen.Task10_11.BLL
{
    public interface IPersonsBL
    {
        IEnumerable<Person> GetPersons();
        void CreatePerson(string name, DateTime dateOfBirth, byte[] image);
        void DeletePerson(int person_id);
        void UpdatePerson(int person_id, string name, DateTime dateOfBirth, byte[] image);
        void AddAward(int person_id, int award_id);
        void RemoveAward(int person_id, int award_id);
    }
}
