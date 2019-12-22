using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.GitHub.Reiqen.Task5Modified
{
    class InformerThread
    {
        public static void OnlineWatcher()
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.IncludeSubdirectories = true;
                watcher.Path = @"C:\Temp";
                watcher.NotifyFilter = NotifyFilters.LastAccess
                     | NotifyFilters.LastWrite
                     | NotifyFilters.FileName
                     | NotifyFilters.DirectoryName;
                watcher.Filter = "*.txt";
                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;
                watcher.EnableRaisingEvents = true;
                Console.WriteLine("Press 'Q' to quit watching mode.");
                while (Console.ReadKey().Key != ConsoleKey.Q) ;
            }
        }
        private static void OnChanged(object source, FileSystemEventArgs e) =>
        Console.WriteLine($"File {e.FullPath} has been {e.ChangeType.ToString().ToLower()}");

        private static void OnRenamed(object source, RenamedEventArgs e) =>
        Console.WriteLine($"File {e.OldFullPath} has been renamed to {e.FullPath}");
    }
}