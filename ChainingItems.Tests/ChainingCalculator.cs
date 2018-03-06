using System;
using System.Collections.Generic;

namespace ChainingItems.Tests
{
    internal class ChainingCalculator
    {
        internal Dictionary<int, Chain> CreateChains(List<Item> items)
        {
            var chains = new Dictionary<int, Chain>();
            foreach (var item in items)
            {
                Chain chain = new Chain();
                if(item.PreviousItemId.HasValue)
                {
                    chain.Add(item.PreviousItemId.Value);
                }

                chain.Add(item.Identifier);
                if (item.FollowingITemId.HasValue)
                {
                    chain.Add(item.FollowingITemId.Value);
                }
                chains.Add(item.Identifier, chain);
            }
            return chains;
        }
    }
}