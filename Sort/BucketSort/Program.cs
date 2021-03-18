using System;

namespace BucketSort
{
    class Program
    {
        static void Main(string[] args)
        {
            BucketSort[] bs = new BucketSort[2];
            Console.WriteLine("TEST BUCKET SORT");
            for (int i = 0; i < bs.Length; i++) 
            {
                Console.WriteLine("TEST #{0}", i);
                bs[i] = new BucketSort();
                bs[i].TestBucketSort((i+1)*50, (i + 1)*10, (i + 1)*50);
            }

                Console.WriteLine("\nTEST EXTENDED SORT");
                BucketSort bsExtended = new BucketSort();
                bsExtended.TestExtendedSort(50,10, 50);
                Console.WriteLine();
        }
    }
}
