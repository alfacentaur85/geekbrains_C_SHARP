using System;

namespace FiboNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Test calc Fibo Number */
            int[,] testArray = new int[7,2]  { { 0, 0 }, { 1, 1 }, { 6, 8 },
                                                    { 7, 13 }, { 12, 144 }, { 13, 233 }, { 20, 6765 } };
            for (int i = 0; i < testArray.GetLength(0); i++)
            {
                Console.WriteLine($"n: {testArray[i, 0] }; Expected: {testArray[i, 1] }; " +
                    $" FiboCycle:  {FiboCycle(testArray[i, 0])}; FiboRecursion {FiboRecursion(testArray[i, 0])}");
            }
            
        }

        /* Calc Fibo Number by cycle */
        static int FiboCycle(int n)
        {
            switch (n)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;

                default:

                    int a = 0;
                    int b = 1;
                    
                    for (int i = 0; i <= n / 2 - 1; i++)
                    {
                        a = a + b;
                        b = a + b;
                    }
                    return (n%2 == 0 ? a : b);
            }
        }

        /* Calc Fibo Number by Recursion */
        static int FiboRecursion(int n)
        {
            switch (n)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    return FiboRecursion(n - 1) + FiboRecursion(n - 2);

            }

        }


    }
}
