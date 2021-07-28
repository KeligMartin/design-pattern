using Microsoft.Data.Sqlite;

namespace ESGI.DesignPattern.Projet
{
    public class InMemoryReceiptRepository : IRepository
    {
        private static readonly string databaseName = "db";
        private static readonly string user = "user";
        private static readonly string pass = "password";
        private static readonly string port = "3307";

        public void Store(Receipt receipt)
        {
            using (var connection = new SqliteConnection
            {
                ConnectionString = $"Database={databaseName}"
            })
            {
                connection.Open();
                var command = new SqliteCommand("insert into RECEIPT(AMOUNT, TAX, TOTAL) values (@amount, @tax, @total)", connection);
                command.Parameters.AddWithValue("@amount", receipt.Amount);
                command.Parameters.AddWithValue("@tax", receipt.Tax);
                command.Parameters.AddWithValue("@total", receipt.Total);
                command.Prepare();
                command.ExecuteNonQuery();

            }
        }
    }
}