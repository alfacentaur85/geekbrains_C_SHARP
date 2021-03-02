using System;

namespace BinarySearch
{
    class Program
    {


        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }




        static void Main(string[] args)
        {

            // Асимптотическая сложность алгоритма Бинарного поиска
            //Источник: http://espressocode.top/complexity-analysis-of-binary-search/
            /*
             Допустим, итерация в двоичном поиске заканчивается после k=3 итераций. 
            На каждой итерации массив делится пополам. Допустим, длина массива на любой итерации равна n
            На итерации 1
            Length of array = n
            На итерации 2
            Length of array = n⁄2
            На итерации 3
            Length of array = (n⁄2)⁄2 = n⁄2^2
            Следовательно, после итерации k
            Length of array = n⁄2^k
            Кроме того, мы знаем, что после
            After k divisions, the length of array becomes 1
            Следовательно
            Length of array = n⁄2^k = 1
                => n = 2k
            Применение функции журнала с обеих сторон:
            => log2 (n) = log2 (2^k)
            => log2 (n) = k log2 (2)
            As (log a (a) = 1)
            Следовательно,
            => k = log2 (n)

            Следовательно, временная сложность бинарного поиска

            log2 (n)       */

            Console.WriteLine("Testing algorithm BinarySearch");
            Console.WriteLine("inputArray: [1, 2, 3, 4, 5, 6, 7, 8, 10, 11, 12, 13, 14, 15], searchValue: 10;  " +
                "Expected: 8; Result: {0}", BinarySearch(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 10, 11, 12, 13, 14, 15}, 10));
            Console.WriteLine("inputArray: [1, 2, 3, 4, 5, 6, 7, 8, 10, 11, 12, 13, 14, 15], searchValue: 1;  " +
                "Expected: 0; Result: {0}", BinarySearch(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 10, 11, 12, 13, 14, 15 }, 1));
            Console.WriteLine("inputArray: [1, 2, 3, 4, 5, 6, 7, 8, 10, 11, 12, 13, 14, 15], searchValue: 16;  " +
                "Expected: -1; Result: {0}", BinarySearch(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 10, 11, 12, 13, 14, 15 }, 16));
            Console.ReadKey();




        }
    }
}
