using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Podaj nazwę pliku (bez rozszerzenia): ");
        string nazwaPliku = Console.ReadLine() + ".txt";

        Console.Write("Podaj numer albumu: ");
        string nrAlbumu = Console.ReadLine();

        try
        {
            File.WriteAllText(nazwaPliku, nrAlbumu);
            Console.WriteLine($"Numer albumu {nrAlbumu} zapisano do pliku {nazwaPliku}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Błąd podczas zapisu do pliku: {e.Message}");
        }
    }
}
