using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace com.GitHub.Reiqen.Task7
{
    class Program
    {
        private static string _valueToCheck;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Task7.");

            // First task solution
            Regex dateRegex = new Regex(@"(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-](19|20)[0-9][0-9]");
            Console.WriteLine("Enter the string:");
            _valueToCheck = Console.ReadLine();
            MatchCollection collection = dateRegex.Matches(_valueToCheck);
            Console.WriteLine("Number of matches: " + collection.Count);

            //Second task solution
            Console.WriteLine("Enter the string:");
            _valueToCheck = Console.ReadLine();
            string result = Regex.Replace(_valueToCheck, @"<[^>]*>", "_");
            Console.WriteLine(result);

            //Third task solution
            Regex mailRegex = new Regex(@"[a-z0-9]+([_\.\-][a-z0-9]+)*@[a-z0-9]+([\.\-][a-z0-9]+)*\.[a-z]{2,6}");
            Console.WriteLine("Enter the string:");
            _valueToCheck = Console.ReadLine();
            collection = mailRegex.Matches(_valueToCheck);
            if (collection.Count > 0)
            {
                Console.WriteLine("E-mails found:");
                foreach (Match item in collection) Console.WriteLine(item.Value);
            }
            else Console.WriteLine("No valid e-mail addresses found.");

            // Fourth task solution
            Regex numberRegex = new Regex(@"^([+|-]?\d+)(.\d*)?(?<scientific>e[-]\d+)?$");
            Console.WriteLine("Enter the string:");
            _valueToCheck = Console.ReadLine();
            Match match = numberRegex.Match(_valueToCheck);
            GroupCollection groups = match.Groups;
            if (numberRegex.IsMatch(_valueToCheck))
            {
                if (groups["scientific"].Value != "") Console.WriteLine("Scientific notation number");
                else Console.WriteLine("Regular notation number");
            }
            else Console.WriteLine("It is not a number");

            // Fifth task solution
            Regex timeRegex = new Regex(@"\b([0-1]?[0-9]):|(2[0-3]:)([0-5][0-9])\b");
            Console.WriteLine("Enter the string:");
            _valueToCheck = Console.ReadLine();
            collection = timeRegex.Matches(_valueToCheck);
            Console.WriteLine("Number of matches: " + collection.Count);
            Console.ReadLine();
        }
    }
}