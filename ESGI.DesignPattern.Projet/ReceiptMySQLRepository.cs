using MySql.Data.MySqlClient;

namespace ESGI.DesignPattern.Projet
{
    public class ReceiptRepository : IRepository
    {
        private static readonly string databaseName = "db";
        private static readonly string user = "user";
        private static readonly string pass = "password";
        private static readonly string port = "3307";

        public void Store(Receipt receipt)
        {
            using (var connection = new MySqlConnection
            {
                ConnectionString = $"Database={databaseName};Data Source=localhost;Port={port};User Id={user};Password={pass}"
            })
            {
                connection.Open();
                var command = new MySqlCommand("insert into receipt (amount, tax, total)"
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
