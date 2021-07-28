using System;
using System.Collections.Generic;

namespace ESGI.DesignPattern.Projet
{
    public class Checkout
    {
        public List<Item> Items { get; }

        public Checkout(List<Item> items)
        {
            Items = items;
        }

        public Receipt CreateReceipt(IRepository repository)
        {
            var receipt = new Receipt();
            receipt.Amount = GetAmount();
            receipt.Taxes = GetTaxes();
            receipt.Total = GetTotal();
            receipt.Tax = GetTotal() - GetAmount();
            
            repository.Store(receipt);
            Console.WriteLine("receipt stored !");
            receipt.DisplayReceipt(this);
            return receipt;
        }

        decimal GetAmount()
        {
            decimal amount = 0;
            Items.ForEach(item => amount += item.Amount);
            return amount;
        }

        decimal GetTotal()
        {
            decimal total = 0;

            Items.ForEach(item => total += item.Amount + item.Amount * item.Tax / 100);
            return total;
        }

        HashSet<decimal> GetTaxes()
        {
            HashSet<decimal> taxes = new HashSet<decimal>();
            
            Items.ForEach(item => taxes.Add(item.Tax));
            return taxes;
        }

        public decimal GetTaxTotal(decimal tax)
        {
            decimal total = 0;
            var items = Items.FindAll(item => item.Tax == tax);
            items.ForEach(item => total += item.Amount * tax / 100);
            return total;
        }
    }
}
