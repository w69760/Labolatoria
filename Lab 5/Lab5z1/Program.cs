namespace KalkulatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Write("Podaj pierwszą liczbę: ");
                    double liczba1 = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Podaj drugą liczbę: ");
                    double liczba2 = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Wybierz operację: 0 - Dodawanie, 1 - Odejmowanie, 2 - Mnożenie, 3 - Dzielenie");
                    Operacja operacja = (Operacja)Enum.Parse(typeof(Operacja), Console.ReadLine());

                    double wynik = Kalkulator.WykonajOperacje(liczba1, liczba2, operacja);
                    Kalkulator.HistoriaWynikow.Add(wynik);

                    Console.WriteLine($"Wynik: {wynik}");
                    Console.WriteLine("Historia wyników: " + string.Join(", ", Kalkulator.HistoriaWynikow));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Błąd: Wprowadzono nieprawidłową wartość. Wprowadź liczbę.");
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine($"Błąd: {e.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Nieoczekiwany błąd: {e.Message}");
                }

                Console.Write("Czy chcesz wykonać kolejne obliczenie? (tak/nie): ");
                if (Console.ReadLine().ToLower() != "tak")
                    break;
            }
        }
    }
}
