using System;

namespace Lesson3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] phoneBook = new string[5, 2];
            Console.WriteLine("ТЕЛЕФОННЫЙ СПРАВОЧНИК");
            //initialize array
            for (int i = 0; i < phoneBook.GetLength(0); i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Контакт {i + 1}");
                Console.Write("Введите ФИО: ");
                phoneBook[i, 0] = Console.ReadLine();
                Console.Write("Введите телефон: ");
                phoneBook[i, 1] = Console.ReadLine();
                Console.Write("Введите e-mail: ");
                phoneBook[i, 1] = phoneBook[i, 1] + '/' + Console.ReadLine();

            }
            //output array
            Console.WriteLine();
            Console.WriteLine("Записи в телефонном справочнике: ");
            for (int i = 0; i < phoneBook.GetLength(0); i++)
            {
                Console.WriteLine($"Контакт {i + 1}: {phoneBook[i, 0]} {phoneBook[i, 1]}");
            }

        }
    }
}
