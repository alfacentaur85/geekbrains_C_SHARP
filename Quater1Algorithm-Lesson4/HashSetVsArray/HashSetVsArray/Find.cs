using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
using System.Runtime.InteropServices;


namespace HashSetVsArray
{
    public class Find
    {
        public static  int GenerateRndIndex(int maxValue)
        {
            Random rnd = new Random();
            return rnd.Next(maxValue);
            
        }

        public  void FindInArray<T>(T[] curArr, T searchValue)
        {
            for(int i = 0; i < curArr.Length; i++)
            {
                if (curArr[i].Equals(searchValue))
                {
                    return;
                }
            }
        }

        public  void FindInHashSet<T>(HashSet<T> curHashSet, T searchValue)
        {
            
            if (curHashSet.Contains(searchValue))
            {
                return;
            }
          
        }


    }
}
