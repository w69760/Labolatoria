class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nWybierz operację:");
            Console.WriteLine("1. Dodaj klienta");
            Console.WriteLine("2. Wyświetl klientów");
            Console.WriteLine("3. Zaktualizuj klienta");
            Console.WriteLine("4. Usuń klienta");
            Console.WriteLine("5. Wyszukaj klienta po nazwisku");
            Console.WriteLine("6. Wyjście");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ClientManager.AddClient();
                    break;
                case "2":
                    ClientManager.DisplayClients();
                    break;
                case "3":
                    ClientManager.UpdateClient();
                    break;
                case "4":
                    ClientManager.DeleteClient();
                    break;
                case "5":
                    ClientManager.SearchClientByLastName();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowy wybór.");
                    break;
            }
        }
    }
}
