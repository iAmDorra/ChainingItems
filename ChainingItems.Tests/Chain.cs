using System;
using System.Collections.Generic;

namespace ChainingItems.Tests
{
    internal class Chain
    {
        private List<int> itemIdentifiers = new List<int>();

        public Chain()
        {
        }
        
        public int this[int index]
        {
            get
            {
                return itemIdentifiers[index];
            }
        }

        internal void Add(int value)
        {
            itemIdentifiers.Add(value);
        }
    }
}