using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Linq;

namespace com.GitHub.Reiqen.Task5Modified
{
    class InformerThread
    {
        private static int _count = 1;
        private static FileSystemWatcher _watcher = new FileSystemWatcher();
        private static XDocument _reportedChanges = new XDocument();
        private static XElement _head = new XElement("ReportedChanges");

        public static void CheckAllDirs(DirectoryInfo dir)
        {
            foreach (var item in dir.GetDirectories())
            {
                Console.WriteLine(item.Name);
                CheckAllDirs(item);
            }
        }

        public static void OnlineWatcher()
        {
            using (_watcher)
            {
                _watcher.IncludeSubdirectories = true;
                _watcher.Path = @"C:\Temp";
                _watcher.NotifyFilter = NotifyFilters.LastAccess
                     | NotifyFilters.LastWrite
                     | NotifyFilters.FileName
                     | NotifyFilters.DirectoryName;
                _watcher.Filter = "*.txt";
                _watcher.Changed += OnChanged;
                _watcher.Created += OnChanged;
                _watcher.Deleted += OnChanged;
                _watcher.Renamed += OnRenamed;

                _watcher.EnableRaisingEvents = true;
                Console.WriteLine("Press 'Q' to quit watching mode.");


                while (Console.ReadKey().Key != ConsoleKey.Q) ;
                _reportedChanges.Add(_head);
                _reportedChanges.Save(@"C:\Temp\temp.xml");
            }
        }
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            if (e.ChangeType.ToString().Equals("Changed"))
            {
                while (true)
                {
                    try
                    {
                        DateTime dt = File.GetLastWriteTime(e.FullPath);
                        using (StreamReader stream = new StreamReader(e.FullPath))
                        {
                            if (stream != null)
                            {
                                XElement note = new XElement("Note");
                                XElement id = new XElement("ID", _count);
                                XElement name = new XElement("Name", e.Name);
                                XElement lastWritten = new XElement("LastWritten", dt.ToString("dd.MM.yyyy HH:mm:ss"));
                                XElement fullPath = new XElement("FullPath", e.FullPath);
                                XElement text = new XElement("Text", stream.ReadToEnd());
                                note.Add(id);
                                note.Add(name);
                                note.Add(lastWritten);
                                note.Add(fullPath);
                                note.Add(text);
                                _head.Add(note);
                                _count++;
                                break;
                            }
                        }
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine("Waiting for the file being ready for logging...");
                    }
                    Thread.Sleep(500);
                }
            }
            Console.WriteLine($"File {e.FullPath} has been {e.ChangeType.ToString().ToLower()}");
        }
        private static void OnRenamed(object source, RenamedEventArgs e) =>
        Console.WriteLine($"File {e.OldFullPath} has been renamed to {e.FullPath}");
    }
}