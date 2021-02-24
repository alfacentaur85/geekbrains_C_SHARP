using System;

namespace SimpleNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //test arrya
            string[,] testArray = new string[6, 2] { { "3", "True" }, { "4", "False" }, { "7", "True" }, 
                                                    { "100", "False" }, { "593", "True" }, { "594", "False" } };
            //check Is Simple number?
            for (int i = 0; i < testArray.GetLength(0); i++)
            {
                Console.WriteLine("n : {0}; Expected: {1}; Result: {2}", testArray[i, 0], testArray[i, 1], IsSimpleNumber(Convert.ToInt32(testArray[i, 0])));
            }
            

        }

        static bool IsSimpleNumber(int n)
        {
            int d = 0;
            int i = 2;
            while (i < n)
            {
                if (n % i == 0)
                {
                    d++;
                }
                
                i++;
            }
            if (d == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
