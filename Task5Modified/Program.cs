using System;
using static com.GitHub.Reiqen.Task5Modified.InformerThread;
using static com.GitHub.Reiqen.Task5Modified.Backup;
using System.IO;
using System.Globalization;

namespace com.GitHub.Reiqen.Task5Modified
{
    class Program
    {
        private static string _valueToCheck;
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Temp");
            if (args[0].Equals("1"))
            {
                Console.WriteLine("Following folders and subfolders are under watching:");
                CheckAllDirs(dir);
                OnlineWatcher();
            }
            if (args[0].Equals("2"))
            {
                Console.WriteLine("Here is the information of all the changes. Pay attention on the date for making backup.");
                ShowXmlInfo();
                Console.WriteLine("Enter the backup date in the format of 'dd.MM.yyyy HH:mm:ss':");
                _valueToCheck = Console.ReadLine();
                if (DateTime.TryParseExact(_valueToCheck, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var inputDate))
                {
                    if (CheckDate(inputDate))
                    {
                        MakeBackup(inputDate);
                        Console.WriteLine("The backup was done for all the files with the log data you wrote.");
                    }
                    else Console.WriteLine("The date you wrote is not found in logs.");
                }
                else Console.WriteLine("Wrong date");
                Console.ReadLine();
            }
        }
    }
}