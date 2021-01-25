using System;

namespace Lesson3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            char O = 'O';
            char X = 'X';
            Console.WriteLine("Морской бой");
            char[,] seaBattle = new char [10, 10] 
               {
                   {O, O, O, X, O, O, O, O, X, O},
                   {O, O, O, O, O, O, O, O, O, O},
                   {O, X, O, X, O, X, X, X, X, O},
                   {O, O, O, X, O, O, O, O, O, O},
                   {X, O, O, O, O, O, X, X, O, O},
                   {X, O, X, X, X, O, O, O, X, O},
                   {X, O, O, O, O, O, O, O, O, O},
                   {O, O, O, O, O, X, O, O, O, X},
                   {O, O, O, O, O, X, O, O, O, X},
                   {O, X, X, O, O, X, O, O, O, O}
               };
            for (int i = 0; i < seaBattle.GetLength(0); i++)
            {
                for (int j = 0; j < seaBattle.GetLength(1); j++)
                {
                    Console.Write($"{seaBattle[i, j]} ");
                }
                Console.WriteLine();
            }
            
        }
    }
}
