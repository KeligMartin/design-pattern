using Npgsql;

namespace ESGI.DesignPattern.Projet
{
    public class ReceiptPostgreRepository : IRepository
    {
        private static readonly string databaseName = "postgres";
        private static readonly string user = "postgres";
        private static readonly string pass = "postgres";

        public void Store(Receipt receipt)
        {
            using (var connection = new NpgsqlConnection
            {
                ConnectionString = $"Host=localhost;Username={user};Password={pass};Database={databaseName}"
            })
            {
                connection.Open();
                var command = new NpgsqlCommand("insert into RECEIPT (AMOUNT, TAX, TOTAL)"
                                                + "values(@amount, @tax, @total);", connection);
                command.Parameters.AddWithValue("@amount", receipt.Amount);
                command.Parameters.AddWithValue("@tax", receipt.Tax);
                command.Parameters.AddWithValue("@total", receipt.Total);
                command.Prepare();
                command.ExecuteNonQuery();
            }
        }
    }
}