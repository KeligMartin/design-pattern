using System;
using System.Collections.Generic;
using System.Text;

namespace ESGI.DesignPattern.Projet
{
    public class Checkout
    {
        public List<Item> Items { get; set; }

        public Checkout(List<Item> items)
        {
            Items = items;
        }

        public void CreateReceipt(decimal tax)
        {
            var receipt = new Receipt();
            receipt.Amount = GetAmount();
            receipt.Taxes = GetTaxes(Items);
            receipt.Total = GetTotal(Items);
            ReceiptRepository.Store(receipt);
            Console.WriteLine("receipt stored !");
        }

        decimal GetAmount()
        {
            decimal amount = 0;
            foreach (var item in Items)
            {
                amount += item.Amount;
            }

            return amount;
        }

        decimal GetTotal(List<Item> items)
        {
            decimal total = 0;
            foreach (var item in items)
            {
                total += item.Amount + (item.Amount * item.Tax / 100);
            }

            return total;
        }

        HashSet<decimal> GetTaxes(List<Item> items)
        {
            HashSet<decimal> taxes = new HashSet<decimal>();

            foreach (var item in items)
            {
                taxes.Add(item.Tax);
            }

            return taxes;
        }
    }
}
