using Microsoft.Data.Sqlite;

namespace ESGI.DesignPattern.Projet
{
    public class InMemoryReceiptRepository : IRepository
    {
        public void Store(Receipt receipt)
        {
            using (var connection = new SqliteConnection
            {
                ConnectionString = $"Data Source=:memory:"
            })
            {
                connection.Open();
                var command = new SqliteCommand("create table RECEIPT(AMOUNT float, TAX float, TOTAL float)",
                    connection);
                command.Prepare();
                command.ExecuteNonQuery();
                command = new SqliteCommand("insert into RECEIPT(AMOUNT, TAX, TOTAL) values (@amount, @tax, @total)", connection);
                command.Parameters.AddWithValue("@amount", receipt.Amount);
                command.Parameters.AddWithValue("@tax", receipt.Tax);
                command.Parameters.AddWithValue("@total", receipt.Total);
                command.Prepare();
                command.ExecuteNonQuery();
            }
        }
    }
}