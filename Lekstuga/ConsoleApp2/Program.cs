using System;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            Console.WriteLine(path);

            string adress = Path.Combine(path, "Downloads", "test.txt");
            Console.WriteLine(adress);

            if (File.Exists(adress))
            {
                Console.WriteLine("file exist");
            }
            else
            {
                Console.WriteLine("file does not exist");
            }

            string fileName = adress;
            using (var sr = new StreamReader(fileName))
            {
                string content = sr.ReadLine();
                Console.WriteLine(content);
            }
            
            using (var sw = new StreamWriter(fileName))
            {
                sw.WriteLine("Skriv något nytt");
                sw.WriteLine("Skriv en sak till");
                sw.WriteLine("Avsluta");
            }

            Console.ReadLine();
        }
    }
}
