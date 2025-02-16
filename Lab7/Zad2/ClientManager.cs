namespace Zad2
{
    class ClientManager
    {
        public static void AddClient()
        {
            Console.Write("Imię: ");
            string firstName = Console.ReadLine() ?? string.Empty;
            Console.Write("Nazwisko: ");
            string lastName = Console.ReadLine() ?? string.Empty;
            Console.Write("Email: ");
            string email = Console.ReadLine() ?? string.Empty;
            Console.Write("Telefon: ");
            string phone = Console.ReadLine() ?? string.Empty;

            if (!ValidationHelper.IsValidEmail(email))
            {
                Console.WriteLine("Niepoprawny format adresu e-mail.");
                return;
            }
            if (!ValidationHelper.IsValidPhone(phone))
            {
                Console.WriteLine("Niepoprawny format numeru telefonu.");
                return;
            }

            var clients = CsvManager.ReadClients();
            int newId = clients.Count > 0 ? clients[^1].Id + 1 : 1;
            clients.Add(new Client { Id = newId, FirstName = firstName, LastName = lastName, Email = email, Phone = phone });
            CsvManager.WriteClients(clients);
            Console.WriteLine("Klient dodany!");
        }

        public static void DisplayClients()
        {
            var clients = CsvManager.ReadClients();
            foreach (var client in clients)
            {
                Console.WriteLine($"{client.Id}: {client.FirstName} {client.LastName}, {client.Email}, {client.Phone}");
            }
        }

        public static void UpdateClient()
        {
            Console.Write("Podaj ID klienta do aktualizacji: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Niepoprawny format ID.");
                return;
            }

            var clients = CsvManager.ReadClients();
            var client = clients.Find(c => c.Id == id);
            if (client == null)
            {
                Console.WriteLine("Klient nie znaleziony.");
                return;
            }

            Console.Write("Nowe imię (pozostaw puste, aby nie zmieniać): ");
            string firstName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(firstName)) client.FirstName = firstName;

            Console.Write("Nowe nazwisko (pozostaw puste, aby nie zmieniać): ");
            string lastName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(lastName)) client.LastName = lastName;

            Console.Write("Nowy e-mail (pozostaw puste, aby nie zmieniać): ");
            string email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email) && ValidationHelper.IsValidEmail(email))
                client.Email = email;
            else if (!string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Niepoprawny format adresu e-mail.");
                return;
            }

            Console.Write("Nowy telefon (pozostaw puste, aby nie zmieniać): ");
            string phone = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(phone) && ValidationHelper.IsValidPhone(phone))
                client.Phone = phone;
            else if (!string.IsNullOrWhiteSpace(phone))
            {
                Console.WriteLine("Niepoprawny format numeru telefonu.");
                return;
            }

            CsvManager.WriteClients(clients);
            Console.WriteLine("Dane klienta zaktualizowane!");
        }

        public static void DeleteClient()
        {
            Console.Write("Podaj ID klienta do usunięcia: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Niepoprawny format ID.");
                return;
            }

            var clients = CsvManager.ReadClients();
            if (clients.RemoveAll(c => c.Id == id) == 0)
            {
                Console.WriteLine("Klient nie znaleziony.");
                return;
            }

            CsvManager.WriteClients(clients);
            Console.WriteLine("Klient usunięty!");
        }
    }
}
