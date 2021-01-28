using System;

namespace lesson4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Сумма введенных чисел = {CalculateSum(InputCacheList())}");
        }

        static string InputCacheList()
        {
            Console.Write("Ведите числа через пробел и нажмите ENTER: ");
            return Console.ReadLine();
        }

        static int CalculateSum(string cacheList)
        {
            int sum = 0;
            string tempCache = "";
            int i = 0;
            while (i < cacheList.Length)
            {
                if (Convert.ToString(cacheList[i]) != " ")
                {
                    tempCache += cacheList[i];
                }
                else
                {
                    sum += Convert.ToInt32(tempCache);
                    tempCache = "";
                }
                i++;
            };

            return sum += Convert.ToInt32(tempCache);

        }

    }
}
