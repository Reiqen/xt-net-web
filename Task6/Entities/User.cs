using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.GitHub.Reiqen.Task6.Entities
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int age { get; set; }
        public List<Award> awards;

        public override string ToString()
        {
            var info = "Name: " + name + ". Date of birth: " + dateOfBirth.ToString("dd.MM.yyyy") + ". Age: " + age + ". Awards:\n";
            if (awards.Any()) foreach (Award award in awards) info += award.ToString() + "\n";
            else info += "No awards.\n";
            return info;
        }
    }
}