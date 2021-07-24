using Npgsql;

namespace ESGI.DesignPattern.Projet
{
    public class ReceiptPostgreRepository : IRepository
    {
        private static readonly string databaseName = "myshop";
        private static readonly string user = "store";
        private static readonly string pass = "123456";

        public void Store(Receipt receipt)
        {
            using (var connection = new NpgsqlConnection
            {
                ConnectionString = $"Database={databaseName};Data Source=localhost;User Id={user};Password={pass}"
            })
            {
                connection.Open();
                var command = new NpgsqlCommand("insert into RECEIPT (AMOUNT, TAX, TOTAL)"
                                                + "values(@amount, @tax, @total);", connection);
                command.Parameters.AddWithValue("@amount", receipt.Amount);
                command.Parameters.AddWithValue("@tax", 10);
                command.Parameters.AddWithValue("@total", receipt.Total);
                command.Prepare();
                command.ExecuteNonQuery();
            }
        }
    }
}