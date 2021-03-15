using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace HashSetVsArray
{
    class Collections
    {
        private int _countItems;

        private HashSet<string> _hashSetOfString = new HashSet<string>();
        public HashSet<string> HashSetOfString
        {
            get
            {
                return _hashSetOfString;
            }
        }

        private List<string> _arrayOfStrings = new List<string>();
        public List<string> ArrayOfStrings
        {
            get 
            {      
                return _arrayOfStrings;
            }
        }

        public Collections(int countItems = 10_000)
        {
            this._countItems = countItems;
            this.FillArrayAndHashSet();

        }

        private void FillArrayAndHashSet() 
        {
            
            for (int i = 0; i < _countItems; i++)
            {
                string str = GenerationString.GetString();
                _hashSetOfString.Add(str);
                _arrayOfStrings.Add(str);
            }
        }







    }
}
