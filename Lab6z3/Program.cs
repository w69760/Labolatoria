using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string nazwaPliku = "pesels.txt";

        try
        {
            List<string> pesels = File.ReadAllLines(nazwaPliku).ToList();
            int liczbaZenskichPeseli = pesels.Count(pesel => IsFemalePesel(pesel));

            Console.WriteLine($"Liczba żeńskich PESELi w pliku: {liczbaZenskichPeseli}");
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

    static bool IsFemalePesel(string pesel)
    {
        if (pesel.Length != 11 || !pesel.All(char.IsDigit))
            return false;

        int genderDigit = int.Parse(pesel[9].ToString());
        return genderDigit % 2 == 0;
    }
}
