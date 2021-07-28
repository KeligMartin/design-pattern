using System;
using System.Collections.Generic;
using Xunit;

namespace ESGI.DesignPattern.Projet.Tests
{
    public class Tests
    {

        [Fact]
        public void should_create_item()
        {
            Item item = new Item("strawberry", 20, 20);
            Assert.Equal("strawberry", item.Name);
        }
        
        [Fact]
        public void should_create_checkout()
        {
            Item item1 = new Item("strawberry", 20, 20);
            Item item2 = new Item("banana", 30, 10);
            List<Item> items = new List<Item>();
            items.Add(item1);
            items.Add(item2);
            Checkout checkout = new Checkout(items);
            Assert.Equal(2, checkout.Items.Count);
        }

        [Fact]
        public void should_store_a_receipt()
        {
            Item item1 = new Item("strawberry", 20, 20);
            Item item2 = new Item("banana", 30, 10);
            List<Item> items = new List<Item>();
            items.Add(item1);
            items.Add(item2);
            Checkout checkout = new Checkout(items);
            Receipt receipt = checkout.CreateReceipt(new InMemoryReceiptRepository());
            Assert.Equal(50, receipt.Amount);
        }

    }
}

