using System;
using System.Collections.Generic;
using System.Linq;

namespace ChainingItems.Tests
{
    internal class ChainingCalculator
    {
        internal Dictionary<int, Chain> CreateChains(List<Item> items)
        {
            var chains = new Dictionary<int, Chain>();
            foreach (var item in items)
            {
                if (item.PreviousItemId.HasValue)
                {
                    AddItem(chains, item.PreviousItemId.Value, item.Identifier);
                    AddItem(chains, item.Identifier, item.PreviousItemId.Value);
                }
                AddItem(chains, item.Identifier, item.Identifier);
                if (item.FollowingITemId.HasValue)
                {
                    AddItem(chains, item.FollowingITemId.Value, item.Identifier);
                    AddItem(chains, item.Identifier, item.FollowingITemId.Value);
                }
            }
            return chains;
        }

        internal List<Chain> IdentifyChains(Dictionary<int, Chain> chains)
        {
            var identifiedChains = new List<Chain>();
            var identifiers = chains.Keys.ToList();
            var index = 0;
            while (index < identifiers.Count)
            {
                var identifiedChain = new Chain();
                var identifier = identifiers[index];
                AddToIdentifiedChain(chains, identifiedChain, identifier);
                identifiedChains.Add(identifiedChain);
                foreach (var item in identifiedChain.ItemIdentifiers)
                {
                    identifiers.Remove(item);
                }
            }

            return identifiedChains;
        }

        private static void AddToIdentifiedChain(Dictionary<int, Chain> chains, Chain identifiedChain, int identifier)
        {
            var chain = chains[identifier];
            foreach (var item in chain.ItemIdentifiers)
            {
                if (identifier != item &&
                    !identifiedChain.Contains(item) &&
                    chains.ContainsKey(item))
                {
                    AddToIdentifiedChain(chains, identifiedChain, item);
                }
                identifiedChain.Add(item);
            }
            identifiedChain.Add(identifier);
        }

        private static void AddItem(Dictionary<int, Chain> chains, int key, int value)
        {
            if (!chains.ContainsKey(key))
            {
                Chain chain = new Chain();
                chain.Add(value);
                chains.Add(key, chain);
            }
            else
            {
                chains[key].Add(value);
            }
        }
    }
}