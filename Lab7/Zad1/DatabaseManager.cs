using Microsoft.Data.SqlClient;

class DatabaseManager
{
    private static readonly string connectionString = "Data Source=PCBYMICHU;Initial Catalog=Lab7;Integrated Security=True;TrustServerCertificate=True;";

    public static void ExecuteQuery(string query, Action<SqlCommand> parameterize = null)
    {
        using SqlConnection conn = new(connectionString);
        conn.Open();
        using SqlCommand cmd = new(query, conn);
        parameterize?.Invoke(cmd);
        cmd.ExecuteNonQuery();
    }

    public static List<Client> GetClients()
    {
        List<Client> clients = [];
        using (SqlConnection conn = new(connectionString))
        {
            conn.Open();
            using SqlCommand cmd = new("SELECT * FROM Klienci", conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                clients.Add(new Client
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Email = reader.GetString(3),
                    Phone = reader.GetString(4),
                    RegistrationDate = reader.GetDateTime(5)
                });
            }
        }
        return clients;
    }
}
