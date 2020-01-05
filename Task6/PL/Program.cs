using com.GitHub.Reiqen.Task6.BLL;
using com.GitHub.Reiqen.Task6.Entities;
using com.GitHub.Reiqen.Task6.Dependencies;
using static com.GitHub.Reiqen.Task6.PL.Corrector;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace com.GitHub.Reiqen.Task6.PL
{
    class Program
    {
        private static string _valueToCheck;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to task6.");
            while (true)
            {
                Console.WriteLine("Choose an option:\n1. Print users and their awards.\n2. Add a user.\n3. Delete user." +
                    "\n4. Add awards to a user.\n5. Close the program.");
                _valueToCheck = Console.ReadLine();
                if (_valueToCheck.Equals("1"))
                {
                    var bl = DependencyResolver.UserBL;
                    IEnumerable<User> users = bl.GetUsers();
                    if (users.Any()) foreach (User user in users) Console.WriteLine(user.ToString());
                    else Console.WriteLine("No users found.");
                }
                else if (_valueToCheck.Equals("2"))
                {
                    var bl = DependencyResolver.UserBL;
                    DateTime dob;
                    Console.WriteLine("Enter name:");
                    string name = Console.ReadLine();
                    while (true)
                    {
                        Console.WriteLine("Enter date of birth:");
                        _valueToCheck = Console.ReadLine();
                        if (IsCorrectDate(_valueToCheck))
                        {
                            dob = DateTime.ParseExact(_valueToCheck, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                            break;
                        }
                        else Console.WriteLine("Wrong date format.");
                    }
                    List<string> titles = new List<string>();
                    while (true)
                    {
                        Console.WriteLine("Do you want to add awards?\n1. Yes.\n2. No.");
                        _valueToCheck = Console.ReadLine();
                        if (_valueToCheck.Equals("1"))
                        {
                            while (true)
                            {
                                Console.WriteLine("How many?");
                                _valueToCheck = Console.ReadLine();
                                if (Int32.TryParse(_valueToCheck, out int number) && number > 0)
                                {
                                    for (int i = 0; i < number; i++)
                                    {
                                        Console.WriteLine("Write award title:");
                                        _valueToCheck = Console.ReadLine();
                                        titles.Add(_valueToCheck);
                                    }
                                    break;
                                }
                                else Console.WriteLine("Wrong input.");
                            }
                            break;
                        }
                        else if (_valueToCheck.Equals("2"))
                        {
                            break;
                        }
                        else Console.WriteLine("Wrong input.");
                    }
                    bl.AddUser(name, dob, titles);
                    Console.WriteLine("Operation is over.");
                }
                else if (_valueToCheck.Equals("3"))
                {
                    int id;
                    var bl = DependencyResolver.UserBL;
                    while (true)
                    {
                        Console.WriteLine("Enter user ID:");
                        _valueToCheck = Console.ReadLine();
                        if (Int32.TryParse(_valueToCheck, out int number) && number > 0)
                        {
                            id = number;
                            break;
                        }
                        else Console.WriteLine("Wrong input.");
                    }
                    bl.DeleteUser(id);
                    Console.WriteLine("Operation is over.");
                }
                else if (_valueToCheck.Equals("4"))
                {
                    var bl = DependencyResolver.UserBL;
                    int id;
                    List<string> titles = new List<string>();
                    while (true)
                    {
                        Console.WriteLine("Enter user ID:");
                        _valueToCheck = Console.ReadLine();
                        if (Int32.TryParse(_valueToCheck, out int idNumber) && idNumber > 0)
                        {
                            id = idNumber;
                            while (true)
                            {
                                Console.WriteLine("How many awards?");
                                _valueToCheck = Console.ReadLine();
                                if (Int32.TryParse(_valueToCheck, out int number) && number > 0)
                                {
                                    for (int i = 0; i < number; i++)
                                    {
                                        Console.WriteLine("Write award title:");
                                        _valueToCheck = Console.ReadLine();
                                        titles.Add(_valueToCheck);
                                    }
                                    break;
                                }
                                else Console.WriteLine("Wrong input.");
                            }
                            break;
                        }
                        else Console.WriteLine("Wrong input.");
                    }
                    bl.AddAwardToUser(id, titles);
                    Console.WriteLine("Operation is over.");
                }
                else if (_valueToCheck.Equals("5"))
                {
                    break;
                }
                else Console.WriteLine("Wrong input.");
            }
        }
    }
}