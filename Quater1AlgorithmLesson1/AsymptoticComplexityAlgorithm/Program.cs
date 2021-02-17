using System;

namespace AsymptoticComplexityAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Асимптотическая сложность алгоритма функции StrangeSum будет равна O(inputArray.Length^3), т.к. использован 3-ой вложенный цикл");
        }


        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray.Length; j++)
                {
                    for (int k = 0; k < inputArray.Length; k++)
                    {
                        int y = 0;

                        if (j != 0)
                        {
                            y = k / j;
                        }

                        sum += inputArray[i] + i + k + j + y;
                    }
                }
            }

            return sum;
        }



    }
}
