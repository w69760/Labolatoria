namespace GraKolory
{
    enum Kolor
    {
        Czerwony,
        Niebieski,
        Zielony,
        Zolty,
        Fioletowy
    }

    class Gra
    {
        private static List<Kolor> kolory = new List<Kolor> { Kolor.Czerwony, Kolor.Niebieski, Kolor.Zielony, Kolor.Zolty, Kolor.Fioletowy };
        private static Random random = new Random();
        private static Kolor wylosowanyKolor = kolory[random.Next(kolory.Count)];

        public static void Start()
        {
            Console.WriteLine("Witaj w grze w zgadywanie kolorów!");
            Console.WriteLine("Dostępne kolory: Czerwony, Niebieski, Zielony, Żółty, Fioletowy");

            while (true)
            {
                try
                {
                    Console.Write("Zgadnij kolor: ");
                    string input = Console.ReadLine();
                    Kolor zgadnietyKolor = (Kolor)Enum.Parse(typeof(Kolor), input, true);

                    if (zgadnietyKolor == wylosowanyKolor)
                    {
                        Console.WriteLine("Gratulacje! Zgadłeś prawidłowy kolor.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Niepoprawny kolor, spróbuj ponownie.");
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Błąd: Wprowadzono nieprawidłowy kolor. Spróbuj ponownie.");
                }
            }
        }
    }
}