using System;
using System.IO;

namespace AppendCurTimeToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            appendTimeToFile(getCurrentTime());
        }

        static string getCurrentTime()
        {
            DateTime curDateTime = new DateTime();
            curDateTime = DateTime.Now;
            return curDateTime.ToLongTimeString();
        }

        static void appendTimeToFile(string currentTime)
        {
            string fileName = "startup.txt";
            File.AppendAllLines(fileName, new[] { currentTime });
        }
    }
}
