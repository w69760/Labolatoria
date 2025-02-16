using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Podaj nazwę pliku (bez rozszerzenia): ");
        string nazwaPliku = Console.ReadLine() + ".txt";

        try
        {
            string zawartosc = File.ReadAllText(nazwaPliku);
            Console.WriteLine($"Zawartość pliku {nazwaPliku}:\n{zawartosc}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Błąd: Plik nie istnieje.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Błąd podczas odczytu pliku: {e.Message}");
        }
    }
}
