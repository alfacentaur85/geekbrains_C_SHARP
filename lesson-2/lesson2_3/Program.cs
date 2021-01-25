using System;

namespace Lesson2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите целое число: ");
            
            int number = Convert.ToInt32(Console.ReadLine());

            if (number % 2 == 0)
            {
                Console.WriteLine("Введено ЧЕТНОЕ число");
            } else
            {
                Console.WriteLine("Введено НЕЧЕТНОЕ число");
            }


        }
    }
}
