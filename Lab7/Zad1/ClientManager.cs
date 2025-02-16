using Zad1;

class ClientManager
{
    public static void AddClient()
    {
        Console.Write("Imię: ");
        string? firstName = Console.ReadLine() ?? string.Empty;

        Console.Write("Nazwisko: ");
        string? lastName = Console.ReadLine() ?? string.Empty;

        Console.Write("Email: ");
        string? email = Console.ReadLine() ?? string.Empty;

        Console.Write("Telefon: ");
        string? phone = Console.ReadLine() ?? string.Empty;


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

        string query = "INSERT INTO Klienci (Imie, Nazwisko, Email, Telefon, DataRejestracji) VALUES (@Imie, @Nazwisko, @Email, @Telefon, GETDATE())";
        DatabaseManager.ExecuteQuery(query, cmd =>
        {
            cmd.Parameters.AddWithValue("@Imie", firstName);
            cmd.Parameters.AddWithValue("@Nazwisko", lastName);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Telefon", phone);
        });
        Console.WriteLine("Klient dodany!");
    }

    public static void DisplayClients()
    {
        var clients = DatabaseManager.GetClients();
        int pageSize = 5;
        int currentPage = 0;
        int totalPages = (int)Math.Ceiling((double)clients.Count / pageSize);

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Strona {currentPage + 1} z {totalPages}\n");

            var pageClients = clients.Skip(currentPage * pageSize).Take(pageSize).ToList();
            foreach (var client in pageClients)
            {
                Console.WriteLine($"{client.Id}: {client.FirstName} {client.LastName}, {client.Email}, {client.Phone}, {client.RegistrationDate}");
            }

            Console.WriteLine("\nNaciśnij [1] Poprzednia, [2] Następna, [3] Wyjście");
            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.D2 && currentPage < totalPages - 1)
            {
                currentPage++;
            }
            else if (key == ConsoleKey.D1 && currentPage > 0)
            {
                currentPage--;
            }
            else if (key == ConsoleKey.D3)
            {
                break;
            }
        }
    }

    public static void SearchClientByLastName()
    {
        Console.Write("Podaj nazwisko do wyszukania: ");
        string lastName = Console.ReadLine();
        var clients = DatabaseManager.GetClients().Where(c => c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase)).ToList();

        if (clients.Count == 0)
        {
            Console.WriteLine("Brak klientów o podanym nazwisku.");
            return;
        }

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

        var clients = DatabaseManager.GetClients();
        var client = clients.Find(c => c.Id == id);
        if (client == null)
        {
            Console.WriteLine("Klient nie znaleziony.");
            return;
        }

        Console.Write("Nowe imię (pozostaw puste, aby nie zmieniać): ");
        string firstName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(firstName))
            client.FirstName = firstName;

        Console.Write("Nowe nazwisko (pozostaw puste, aby nie zmieniać): ");
        string lastName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(lastName))
            client.LastName = lastName;

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

        string query = "UPDATE Klienci SET Imie = @Imie, Nazwisko = @Nazwisko, Email = @Email, Telefon = @Telefon WHERE Id = @Id";
        DatabaseManager.ExecuteQuery(query, cmd =>
        {
            cmd.Parameters.AddWithValue("@Imie", client.FirstName);
            cmd.Parameters.AddWithValue("@Nazwisko", client.LastName);
            cmd.Parameters.AddWithValue("@Email", client.Email);
            cmd.Parameters.AddWithValue("@Telefon", client.Phone);
            cmd.Parameters.AddWithValue("@Id", id);
        });

        Console.WriteLine("Dane klienta zaktualizowane!");
    }

    public static void DeleteClient()
    {
        Console.Write("Podaj ID klienta do usunięcia: ");
        int id = int.Parse(Console.ReadLine());
        string query = "DELETE FROM Klienci WHERE Id = @Id";
        DatabaseManager.ExecuteQuery(query, cmd =>
        {
            cmd.Parameters.AddWithValue("@Id", id);
        });
        Console.WriteLine("Klient usunięty!");
    }
}
