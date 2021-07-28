using System;
using System.Collections.Generic;

namespace ESGI.DesignPattern.Projet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Item item1 = new Item("strawberry", 20, 20);
            Item item2 = new Item("banana", 30, 10);
            List<Item> items = new List<Item>();
            items.Add(item1);
            items.Add(item2);
            Checkout checkout = new Checkout(items);
            checkout.CreateReceipt(new ReceiptPostgreRepository());
        }
    }
    
    // TODO implémenter les tests
}
