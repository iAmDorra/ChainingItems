using System;
using System.Collections.Generic;

namespace ChainingItems.Tests
{
    internal class Chain
    {
        private List<int> itemIdentifiers = new List<int>();

        public List<int> ItemIdentifiers { get => itemIdentifiers; }

        public Chain()
        {
        }

        public int this[int index]
        {
            get
            {
                return ItemIdentifiers[index];
            }
        }

        internal void Add(int value)
        {
            if (!ItemIdentifiers.Contains(value))
            {
                ItemIdentifiers.Add(value);
            }
        }

        public bool Contains(int value)
        {
            return ItemIdentifiers.Contains(value);
        }
        
    }
}