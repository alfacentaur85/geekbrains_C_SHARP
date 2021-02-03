using System;
using System.IO;

namespace lesson5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveTextToFile(GetInpuString());
        }

        static string GetInpuString()
        {
            Console.WriteLine("Введите произвольный набор данных и нажмите Enter:");
            return Console.ReadLine();
        }

        static void SaveTextToFile(string inputString)
        {
            string fileName = "output.txt";
            File.WriteAllText(fileName, inputString);
        }

    }
}
