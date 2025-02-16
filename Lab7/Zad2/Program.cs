using Zad2;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nWybierz operację:");
            Console.WriteLine("1. Dodaj klienta");
            Console.WriteLine("2. Wyświetl klientów");
            Console.WriteLine("3. Zaktualizuj dane klienta");
            Console.WriteLine("4. Usuń klienta");
            Console.WriteLine("5. Wyjście");
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
                    return;
                default:
                    Console.WriteLine("Nieprawidłowy wybór.");
                    break;
            }
        }
    }
}
