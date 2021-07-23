using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ESGI.DesignPattern.Projet
{
    public class Receipt
    {
        public decimal Amount { get; set; }
        public HashSet<decimal> Taxes { get; set; }
        public decimal Total { get; set; }

        public void DisplayReceipt(Checkout checkout)
        {
            Console.WriteLine("Receipt");
            Console.WriteLine("=======");
            Console.WriteLine("Items : " + checkout.Items.Count);
            foreach (var item in checkout.Items)
            {
                Console.WriteLine(item.Name + " " + item.Amount);
            }
            Console.WriteLine("Amount without taxes = " + Amount);
            Console.WriteLine("Tax : " + Taxes);
            foreach (var tax in Taxes)
            {
                Console.WriteLine("tax " + tax);
            }

            Console.WriteLine("Total : " + Total);
        }

        public IEnumerable<string> Format(Checkout checkout)
        {
            return new List<string>() { //
                    "Receipt", //
                    "=======", //
                    "Item 1 ... " + Amount, //
                    "Tax    ... " + Taxes, //
                    "----------------", //
                    "Total  ... " + Total //
            };
        }
    }
    // TOOD ajouter une liste d'Item dans Receipt
}
