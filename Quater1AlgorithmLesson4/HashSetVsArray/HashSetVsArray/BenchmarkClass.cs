using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
using System.Runtime.InteropServices;

namespace HashSetVsArray
{
    public class BenchmarkClass
    {
        Collections _collection;
        Find _curFind;
        string _searchValue;
        public BenchmarkClass()
        {
            _collection = new Collections();

            _curFind = new Find();

            _searchValue = _collection.ArrayOfStrings[Find.GenerateRndIndex(_collection.ArrayOfStrings.ToArray().Length - 1)];



        }

        [Benchmark]
        public void TestFindInArray()
        {
            _curFind.FindInArray<string>(_collection.ArrayOfStrings.ToArray(), _searchValue);
            
        }

        [Benchmark]
        public void TestFindInHashSet()
        {
            _curFind.FindInHashSet(_collection.HashSetOfString, _searchValue);
        }

    }
}
