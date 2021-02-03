using System;

namespace lesson_4
{
    class Program
    {
        static void Main(string[] args)
        {
            outputCache(Fibo(HeaderAndInputN()));
        }

        static int Fibo(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            } 
            else
            {
                return Fibo(n - 1) + Fibo(n - 2);
            }
            
        }

        static int HeaderAndInputN()
        {
            Console.WriteLine("ОПРЕДЕЛЕНИЕ ЧИСЛА ФИБОНАЧЧИ");
            Console.WriteLine();
            Console.Write("Введите порядковый номер числа: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static void outputCache(int fibo)
        {
            Console.WriteLine($"Число Фибоначчи - {fibo}");
        }

    }

    
}
