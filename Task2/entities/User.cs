using System;

namespace com.GitHub.Reiqen.Task2.entities
{
    class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        protected int Age()
        {
            int age = new DateTime(DateTime.Now.Subtract(DateOfBirth).Ticks).Year - 1;
            return age;
        }

        public override string ToString()
        {
            string info = string.Format("Пользователь {0} {1}, дата рождения: {2}, возраст: {3}",
                                        Name, Surname, DateOfBirth.ToString("dd.MM.yyyy"), Age());
            return info;
        }
    }
}