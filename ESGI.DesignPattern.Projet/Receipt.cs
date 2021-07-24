using System;
using System.Collections.Generic;

namespace ESGI.DesignPattern.Projet
{
    public class Receipt
    {
        public decimal Amount { get; set; }
        
        public decimal Tax { get; set; }
        public HashSet<decimal> Taxes { get; set; }
        public decimal Total { get; set; }

        public void DisplayReceipt(Checkout checkout)
        {
            Console.WriteLine("Receipt");
            Console.WriteLine("=======");
            Console.WriteLine("Items : " + checkout.Items.Count);
            foreach (var item in checkout.Items)
            {
                Console.WriteLine(item.Name + " " + item.Amount + " EUR");
            }

            Console.WriteLine("Amount without taxes = " + Amount + " EUR");
            Console.WriteLine("Taxes : ");
            foreach (var tax in Taxes)
            {
                Console.WriteLine(tax + "% ---- " + checkout.GetTaxTotal(tax) + " EUR");
            }

            Console.WriteLine("Total : " + Total + " EUR");
        }
    }
}
