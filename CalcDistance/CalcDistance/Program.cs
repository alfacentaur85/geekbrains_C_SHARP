using System;
using System.Collections.Generic;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
using System.Runtime.InteropServices;

namespace CalcDistance
{
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct FloatIntUnion
    {
        [FieldOffset(0)]
        public int i;

        [FieldOffset(0)]
        public float f;
    }

    public class PointClass
    {
        public float X;
        public float Y;
    }

    public struct PointStruct<T>
    {
        public T X;
        public T Y;
    }

    public class BenchmarkClass
    {
        const int countItems = 100;

        static List<PointClass> PointClassList = new List<PointClass>();

        static (List<PointStruct<double>>, List<PointStruct<float>>) PointStructListTuple = (new List<PointStruct<double>>(), new List<PointStruct<float>>());

        public static void FillStructByValues()
        {
            (double X, double Y) CoordXY;

            var rand = new Random();

            for (int i = 0; i < countItems; i++)
            {
                CoordXY.X = rand.NextDouble() * 100;
                CoordXY.Y = rand.NextDouble() * 100;

                PointStruct<double> pointStructD = new PointStruct<double>();
                pointStructD.X = CoordXY.X;
                pointStructD.Y = CoordXY.Y;
                PointStructListTuple.Item1.Add(pointStructD);

                PointStruct<float> pointStructF = new PointStruct<float>();
                pointStructF.X = (float)CoordXY.X;
                pointStructF.Y = (float)CoordXY.Y;
                PointStructListTuple.Item2.Add(pointStructF);

                PointClass pointClass = new PointClass();
                pointClass.X = (float)CoordXY.X;
                pointClass.Y = (float)CoordXY.Y;
                PointClassList.Add(pointClass);

            }
        }

        public static float PointDistanceStructFloatCoord(PointStruct<float> pointOne, PointStruct<float> pointTwo)
        {

            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public static float PointDistanceClassFloatCoord(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public static double PointDistanceStructDoubleCoord(PointStruct<double> pointOne, PointStruct<double> pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

       

        public static float fsrt(float z)
        {
            if (z == 0) return 0;
            FloatIntUnion u;
            u.i = 0;
            u.f = z;
            u.i -= 1 << 23; /* Subtract 2^m. */
            u.i >>= 1; /* Divide by 2. */
            u.i += 1 << 29; /* Add ((b + 1) / 2) * 2^m. */
            return u.f;
        }



        public static float PointDistanceShortFloatCoord(PointStruct<float> pointOne, PointStruct<float> pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return fsrt((x * x) + (y * y));

        }

        [Benchmark]
        public  void TestPointDistanceStructFloatCoordShort()
        {
            foreach (PointStruct<float> point in PointStructListTuple.Item2)
            {
                if (PointStructListTuple.Item2.IndexOf(point) % 2 == 0)
                {
                    PointDistanceShortFloatCoord(point, PointStructListTuple.Item2[PointStructListTuple.Item2.IndexOf(point) + 1]);
                }

            }

        }

        [Benchmark]
        public  void TestPointDistanceClassFloatCoord()
        {
            foreach (PointClass point in PointClassList)
            {
                if (PointClassList.IndexOf(point) % 2 == 0)
                {
                    PointDistanceClassFloatCoord(point, PointClassList[PointClassList.IndexOf(point) + 1]);
                }

            }

        }

        [Benchmark]
        public  void TestPointDistanceStructFloatCoord()
        {
            foreach (PointStruct<float> point in PointStructListTuple.Item2)
            {
                if (PointStructListTuple.Item2.IndexOf(point) % 2 == 0)
                {
                    PointDistanceStructFloatCoord(point, PointStructListTuple.Item2[PointStructListTuple.Item2.IndexOf(point) + 1]);
                }

            }

        }

        [Benchmark]
        public  void TestPointDistanceStructDoubleCoord()
        {
            foreach (PointStruct<double> point in PointStructListTuple.Item1)
            {
                if (PointStructListTuple.Item1.IndexOf(point) % 2 == 0)
                {
                    PointDistanceStructDoubleCoord(point, PointStructListTuple.Item1[PointStructListTuple.Item1.IndexOf(point) + 1]);
                }

            }

        }

    }

  /*                              Method |      Mean |     Error |    StdDev |
|--------------------------------------- |----------:|----------:|----------:|
| TestPointDistanceStructFloatCoordShort | 26.455 ns | 0.5747 ns | 1.4205 ns |
| TestPointDistanceClassFloatCoord       |  7.719 ns | 0.2266 ns | 0.6646 ns |
| TestPointDistanceStructFloatCoord      | 26.090 ns | 0.5713 ns | 1.0155 ns |
| TestPointDistanceStructDoubleCoord     | 27.912 ns | 0.7031 ns | 2.0511 ns |*/
    class Program
    {
       
        static void Main(string[] args)
        {

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

        }   
    }



}
