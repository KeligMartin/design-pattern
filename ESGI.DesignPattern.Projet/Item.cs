namespace ESGI.DesignPattern.Projet
{
    public class Item
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        
        public decimal Tax { get; set; }
        

        public Item(string name, decimal amount, decimal tax)
        {
            Name = name;
            Amount = amount;
            Tax = tax;
        }

    }
}