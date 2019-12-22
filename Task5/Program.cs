using System;
using System.IO;


namespace Task5
{
    class Program
    {
        private static bool flagForWrite = true;
        private static string pathToCatalog;

        [STAThread]
        static void Main()
        {
            try
            {
                if (flagForWrite)
                {
                    flagForWrite = false;
                    Console.WriteLine("Type folder path:");
                    pathToCatalog = Console.ReadLine();
                }

                var informer = new Informer(@pathToCatalog);
                Console.ReadLine();
                informer.Dispose();
            }
            catch
                (DirectoryNotFoundException
                exception)
            {
                Console.WriteLine(exception.Message);

                Console.WriteLine("No such path. Press 'Y' to create it or 'N' to decline.");

                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    try
                    {
                        Directory.CreateDirectory(exception.Message);
                        Console.Clear();

                        Main();
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    return;
                }
            }
        }
    }
}