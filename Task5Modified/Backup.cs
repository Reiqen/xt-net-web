using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;

namespace com.GitHub.Reiqen.Task5Modified
{
    class Backup
    {
        private static Dictionary<int, Tuple<string,
                                             DateTime,
                                             string,
                                             string>> _nodeDict = new Dictionary<int, Tuple<string,
                                                                                           DateTime,
                                                                                           string,
                                                                                           string>>();

        private static void PackXmlInfo()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Temp\temp.xml");

            XmlNodeList noteList = doc.GetElementsByTagName("Note");
            foreach (XmlNode note in noteList)
            {
                int id = Int32.Parse(note["ID"].InnerText);
                string name = note["Name"].InnerText;
                DateTime date = DateTime.ParseExact(note["LastWritten"].InnerText, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                string path = note["FullPath"].InnerText;
                string text = note["Text"].InnerText;
                _nodeDict.Add(id, new Tuple<string, DateTime, string, string>(name, date, path, text));
            }
        }

        public static void ShowXmlInfo()
        {
            PackXmlInfo();
            for (int i = 0; i < _nodeDict.Count; i++)
            {
                var value = _nodeDict[i + 1];
                Console.WriteLine("\nNote " + _nodeDict.Keys.ElementAt(i) + ".\nName of the file: " + value.Item1 + ". Date of change: " 
                    + value.Item2 + ". Path: " + value.Item3 + ". Inner text:\n" + value.Item4);
            }
        }

        public static bool CheckDate(DateTime inputDate)
        {
            bool checker = false;
            for (int i = 0; i < _nodeDict.Count; i++) if (_nodeDict[i + 1].Item2.Equals(inputDate)) checker = true;
            return checker;
        }
        public static void MakeBackup(DateTime inputDate)
        {
            for (int i = 0; i < _nodeDict.Count; i++)
            {
                if (_nodeDict[i + 1].Item2.Equals(inputDate))
                {
                    using (StreamWriter writer = File.CreateText(_nodeDict[i + 1].Item3)) writer.WriteLine(_nodeDict[i + 1].Item4);
                } 
            }
        }
    }
}