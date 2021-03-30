using System;

namespace CountRoutes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Count Routes");
            
            //Testing 1
            CountRoutesMN.M = 3;
            CountRoutesMN.N = 3;
            Console.Write("\ntable size: {0} x {1}; ", CountRoutesMN.M, CountRoutesMN.N);
            Console.Write("expected: 6; ");
            Console.WriteLine($"result: { CountRoutesMN.recursionCountRoutes(CountRoutesMN.M, CountRoutesMN.N)} ");

            //Testing 2
            CountRoutesMN.M = 4;
            CountRoutesMN.N = 3;
            Console.Write("table size: {0} x {1}; ", CountRoutesMN.M, CountRoutesMN.N);
            Console.Write("expected: 10; ");
            Console.WriteLine($"result: { CountRoutesMN.recursionCountRoutes(CountRoutesMN.M, CountRoutesMN.N)} ");

            //Testing 3
            CountRoutesMN.M = 4;
            CountRoutesMN.N = 4;
            Console.Write("table size: {0} x {1}; ", CountRoutesMN.M, CountRoutesMN.N);
            Console.Write("expected: 20; ");
            Console.WriteLine($"result: { CountRoutesMN.recursionCountRoutes(CountRoutesMN.M, CountRoutesMN.N)} ");

            //Testing 4
            CountRoutesMN.M = 5;
            CountRoutesMN.N = 4;
            Console.Write("table size: {0} x {1}; ", CountRoutesMN.M, CountRoutesMN.N);
            Console.Write("expected: 35; ");
            Console.WriteLine($"result: { CountRoutesMN.recursionCountRoutes(CountRoutesMN.M, CountRoutesMN.N)} ");

            //Testing 5
            CountRoutesMN.M = 5;
            CountRoutesMN.N = 5;
            Console.Write("table size: {0} x {1}; ", CountRoutesMN.M, CountRoutesMN.N);
            Console.Write("expected: 70; ");
            Console.WriteLine($"result: { CountRoutesMN.recursionCountRoutes(CountRoutesMN.M, CountRoutesMN.N)} ");
        }

        
    }
}
