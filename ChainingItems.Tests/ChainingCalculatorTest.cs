using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace ChainingItems.Tests
{
    [TestClass]
    public class ChainingCalculatorTest
    {
        [TestMethod]
        public void Should_return_on_chain_when_having_one_item()
        {
            var itemIdentifier = 11;
            var items = new List<Item> { new Item(itemIdentifier, null, null) };
            ChainingCalculator calculator = new ChainingCalculator();
            var chains = calculator.CreateChains(items);

            Check.That(chains[11][0]).IsEqualTo(itemIdentifier);
        }

        [TestMethod]
        public void Should_return_two_chains_when_having_two_items_with_no_previous_and_following_items()
        {
            var items = new List<Item>
            {
                new Item(11, null, null),
                new Item(10, null, null)
            };
            ChainingCalculator calculator = new ChainingCalculator();
            var chains = calculator.CreateChains(items);

            Check.That(chains[11][0]).IsEqualTo(11);
            Check.That(chains[10][0]).IsEqualTo(10);
        }

        [TestMethod]
        public void Should_return_on_chain_when_having_one_item_with_his_previous_one()
        {
            var items = new List<Item> { new Item(8, 9, null) };
            ChainingCalculator calculator = new ChainingCalculator();
            var chains = calculator.CreateChains(items);

            Check.That(chains[8][0]).IsEqualTo(9);
            Check.That(chains[8][1]).IsEqualTo(8);
        }

        [TestMethod]
        public void Should_return_on_chain_when_having_one_item_with_his_following_one()
        {
            var items = new List<Item> { new Item(9, null, 8) };
            ChainingCalculator calculator = new ChainingCalculator();
            var chains = calculator.CreateChains(items);

            Check.That(chains[9][0]).IsEqualTo(9);
            Check.That(chains[9][1]).IsEqualTo(8);
        }

        [TestMethod]
        public void Should_return_two_chains_when_having_two_items_with_following_and_previous_ones()
        {
            var items = new List<Item> {
                new Item(9, null, 8),
                new Item(8, 9, null),
                new Item(5, 8, null)
            };
            ChainingCalculator calculator = new ChainingCalculator();
            var chains = calculator.CreateChains(items);

            Check.That(chains[8].Contains(9)).IsTrue();
            Check.That(chains[8].Contains(8)).IsTrue();
            Check.That(chains[8].Contains(5)).IsTrue();

            Check.That(chains[9].Contains(9)).IsTrue();
            Check.That(chains[9].Contains(8)).IsTrue();
            //Check.That(chains[9].Contains(5)).IsTrue();

            Check.That(chains[5].Contains(8)).IsTrue();
            Check.That(chains[5].Contains(5)).IsTrue();
            //Check.That(chains[5].Contains(9)).IsTrue();
        }

        [TestMethod]
        public void Should_identify_chain_with_one_chain_element()
        {
            Dictionary<int, Chain> chains = new Dictionary<int, Chain>();
            AddChain(chains, 5, new List<int> { 5 });

            ChainingCalculator calculator = new ChainingCalculator();
            var identifiedChains = calculator.IdentifyChains(chains);

            Check.That(identifiedChains[0].Contains(5)).IsTrue();
        }

        [TestMethod]
        public void Should_identify_chain_with_two_chain_elements()
        {
            Dictionary<int, Chain> chains = new Dictionary<int, Chain>();
            AddChain(chains, 5, new List<int> { 8 });

            ChainingCalculator calculator = new ChainingCalculator();
            var identifiedChains = calculator.IdentifyChains(chains);

            Check.That(identifiedChains[0].Contains(5)).IsTrue();
            Check.That(identifiedChains[0].Contains(8)).IsTrue();
        }

        [TestMethod]
        public void Should_identify_one_chain()
        {
            Dictionary<int, Chain> chains = new Dictionary<int, Chain>();
            AddChain(chains, 5, new List<int> { 5, 8 });
            AddChain(chains, 8, new List<int> { 9, 8, 5 });
            AddChain(chains, 9, new List<int> { 9, 8 });

            ChainingCalculator calculator = new ChainingCalculator();
            var identifiedChains = calculator.IdentifyChains(chains);

            Check.That(identifiedChains[0].Contains(8)).IsTrue();
            Check.That(identifiedChains[0].Contains(9)).IsTrue();
            Check.That(identifiedChains[0].Contains(5)).IsTrue();
            Check.That(identifiedChains.Count).IsEqualTo(1);
        }

        [TestMethod]
        public void Should_identify_two_chains()
        {
            Dictionary<int, Chain> chains = new Dictionary<int, Chain>();
            AddChain(chains, 5, new List<int> { 5, 8 });
            AddChain(chains, 7, new List<int> { 6, 7 });
            AddChain(chains, 8, new List<int> { 9, 8, 5 });
            AddChain(chains, 9, new List<int> { 9, 8 });
            AddChain(chains, 6, new List<int> { 6, 7 });

            ChainingCalculator calculator = new ChainingCalculator();
            var identifiedChains = calculator.IdentifyChains(chains);

            Check.That(identifiedChains[0].Contains(8)).IsTrue();
            Check.That(identifiedChains[0].Contains(9)).IsTrue();
            Check.That(identifiedChains[0].Contains(5)).IsTrue();

            Check.That(identifiedChains[1].Contains(6)).IsTrue();
            Check.That(identifiedChains[1].Contains(7)).IsTrue();
            Check.That(identifiedChains.Count).IsEqualTo(2);
        }

        // Integration_test
        [TestMethod]
        public void Should_return_four_identified_chains()
        {
            var items = new List<Item> {
                new Item(11, null, null),
                new Item(10, null, null),
                new Item(9, null, 8),
                new Item(8, 9, null),
                new Item(7, null, null),
                new Item(6, null, 7),
                new Item(5, 8, null)
            };
            ChainingCalculator calculator = new ChainingCalculator();
            var chains = calculator.CreateChains(items);
            var identifiedChains = calculator.IdentifyChains(chains);

            Check.That(identifiedChains.Count).IsEqualTo(4);
        }

        private static void AddChain(Dictionary<int, Chain> chains, int identifier, List<int> values)
        {
            var chain = new Chain();
            foreach (var item in values)
            {
                chain.Add(item);
            }
            chains.Add(identifier, chain);
        }
    }
}
