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
    }
}
