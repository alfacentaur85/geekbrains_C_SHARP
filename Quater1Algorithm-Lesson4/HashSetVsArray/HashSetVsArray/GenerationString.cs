using System;
using System.Collections.Generic;
using System.Text;

namespace HashSetVsArray
{
    static class GenerationString
    {

        static Random rnd = new Random();

        readonly static char[] _symbols = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o',
           'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

        static char getRandomSymbol()
        {
            return _symbols[rnd.Next(_symbols.Length - 1)];
        }

        public static string GetString(int strLength = 10)
        {
            string _result = "";
            for(int i = 0; i < strLength; i++)
            {
                _result += getRandomSymbol();
            }
            return _result;
        }

    }
}
