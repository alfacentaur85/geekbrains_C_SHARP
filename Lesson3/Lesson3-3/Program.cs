using System;

namespace Lesson3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string str = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Обратная строка: ");
            for (int i = str.Length - 1; i >= 0; i--)
            {
                Console.Write($"{str[i]}");
            }
            Console.WriteLine();
        }
    }
}
