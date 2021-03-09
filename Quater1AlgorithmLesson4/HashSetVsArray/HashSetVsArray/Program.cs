using System;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
using System.Runtime.InteropServices;

namespace HashSetVsArray
{
  
/*|          Method |          Mean |        Error |       StdDev |        Median |
|------------------ |--------------:|-------------:|-------------:|--------------:|
|   TestFindInArray | 132,960.64 ns | 9,651.485 ns | 28,457.62 ns | 123,401.53 ns |
| TestFindInHashSet |      53.69 ns |     3.743 ns |     11.04 ns |      51.18 ns |*/

    class Program
    {
        static void Main(string[] args)
        {
          
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

        }




    }
}
