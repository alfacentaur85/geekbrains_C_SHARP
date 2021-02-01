using System;

namespace Lesson3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер первого измерения массива: ");
            int dimension1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите размер второго измерения массива: ");
            int dimension2 = Convert.ToInt32(Console.ReadLine());
            
            int[,] array = new int[dimension1, dimension2];
            //initialize and output array
            Console.WriteLine("Сгенерированный массив:");
            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(10, 99);
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }

            //Output elements of main diagonal
            Console.WriteLine("Элементы главной диагонали:");
            for (int j = 0; (j < array.GetLength(0) && j < array.GetLength(1)); j++)
            {
                Console.Write($"{array[j, j]} ");
            }

        }
    }
}
