using System;

namespace com.GitHub.Reiqen.Task2.entities
{
    class Employee: User
    {
        public DateTime DateOfHire { get; set; }
        public string Position { get; set; }

        private int[] GetExperience()
        {
            var experience = new int[2];
            experience[0] = new DateTime(DateTime.Now.Subtract(DateOfHire).Ticks).Year - 1;
            experience[1] = new DateTime(DateTime.Now.Subtract(DateOfHire).Ticks).Month - 1;
            return experience;
        }

        public override string ToString()
        {
            string info = string.Format("Работник {0} {1}, дата рождения: {2}, возраст: {3}," +
                                        " стаж работы: лет - {4}, месяцев - {5}, должность: {6}",
                                        Name, Surname, DateOfBirth.ToString("dd.MM.yyyy"), Age(),
                                        GetExperience()[0], GetExperience()[1], Position);
            return info;
        }
    }
}