using System;
using static com.GitHub.Reiqen.Task5Modified.InformerThread;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.GitHub.Reiqen.Task5Modified
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Temp");
            CheckAllDirs(dir);
            OnlineWatcher();
            //Console.ReadLine();
        }

        public static void CheckAllDirs(DirectoryInfo dir)
        {
            foreach (var item in dir.GetDirectories())
            {
                Console.WriteLine(item.Name);
                CheckAllDirs(item);
            }
        }
    }
}