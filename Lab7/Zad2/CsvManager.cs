using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Zad2
{
    class CsvManager
    {
        private static string filePath = "clients.csv";

        public static List<Client> ReadClients()
        {
            if (!File.Exists(filePath)) return new List<Client>();
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
            return csv.GetRecords<Client>().ToList();
        }

        public static void WriteClients(List<Client> clients)
        {
            using var writer = new StreamWriter(filePath);
            using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture));
            csv.WriteRecords(clients);
        }
    }
}
