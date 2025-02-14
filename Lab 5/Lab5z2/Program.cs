namespace SklepApp
{
    class Program
    {
        static void Main()
        {
            Sklep sklep = new Sklep();
            sklep.DodajZamowienie(1, new List<string> { "Jabłko", "Banan" });
            sklep.DodajZamowienie(2, new List<string> { "Mleko", "Chleb" });

            while (true)
            {
                Console.WriteLine("Dostępne opcje: 1 - Wyświetl zamówienia, 2 - Zmień status zamówienia, 3 - Wyjście");
                string wybor = Console.ReadLine();

                if (wybor == "1")
                {
                    sklep.WyswietlZamowienia();
                }
                else if (wybor == "2")
                {
                    try
                    {
                        Console.Write("Podaj numer zamówienia: ");
                        int numer = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Wybierz nowy status: 0 - Oczekujące, 1 - Przyjęte, 2 - Zrealizowane, 3 - Anulowane");
                        StatusZamowienia nowyStatus = (StatusZamowienia)Enum.Parse(typeof(StatusZamowienia), Console.ReadLine());

                        sklep.ZmienStatusZamowienia(numer, nowyStatus);
                        Console.WriteLine("Status zamówienia został zmieniony.");
                    }
                    catch (KeyNotFoundException e)
                    {
                        Console.WriteLine($"Błąd: {e.Message}");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"Błąd: {e.Message}");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Błąd: Wprowadzono nieprawidłową wartość.");
                    }
                }
                else if (wybor == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Nieznana opcja, spróbuj ponownie.");
                }
            }
        }
    }
}
