using System;
using System.Collections.Generic;
using Projekt.ZarzadzaniePojazdami.Klasy;
using Projekt.ZarzadzaniePojazdami.Interfejsy;
using Microsoft.Data.SqlClient;

namespace Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=DESKTOP-R3DOJ3V\\SQLEXPRESS;Database=ZarzadzaniePojazdami;Trusted_Connection=True;TrustServerCertificate=True;";
            string sciezkaPliku = "pojazdy.txt";

            // Sprawdzenie połączenia z bazą danych
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Polaczenie z baza danych dziala poprawnie.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Blad polaczenia: " + ex.Message);
                }
            }

            IBazaDanych baza = new BazaDanychHybrydowa(sciezkaPliku, connectionString);
            IBazaDanych bazaSQL = new BazaDanychSQL(connectionString);

            bool dzialanie = true;

            while (dzialanie)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Dodaj nowy pojazd");
                Console.WriteLine("2. Usun pojazd");
                Console.WriteLine("3. Edytuj rejestracje pojazdu");
                Console.WriteLine("4. Wyszukaj pojazd po rejestracji");
                Console.WriteLine("5. Wyswietl wszystkie pojazdy");
                Console.WriteLine("6. Wyswietl pojazdy danego typu");
                Console.WriteLine("7. Pokaz statystyki pojazdow");
                Console.WriteLine("8. Eksportuj wszystkie pojazdy z pliku do SQL");
                Console.WriteLine("0. Wyjscie");
                Console.Write("Wybierz opcje: ");

                string opcja = Console.ReadLine() ?? "";

                switch (opcja)
                {
                    case "1":
                        baza.DodajNowyPojazd();
                        break;
                    case "2":
                        Console.Write("Podaj rejestracje pojazdu do usuniecia: ");
                        string rejestracja = Console.ReadLine() ?? "";
                        baza.UsunPojazd(rejestracja);
                        break;
                    case "3":
                        Console.Write("Podaj stara rejestracje: ");
                        string staraRejestracja = Console.ReadLine() ?? "";
                        Console.Write("Podaj nowa rejestracje: ");
                        string nowaRejestracja = Console.ReadLine() ?? "";
                        baza.EdytujRejestracje(staraRejestracja, nowaRejestracja);
                        break;
                    case "4":
                        Console.Write("Podaj rejestracje: ");
                        string rej = Console.ReadLine() ?? "";
                        var pojazd = baza.WyszukajPojazd(rej);
                        Console.WriteLine(pojazd != null ? pojazd.PobierzDane() : "Pojazd nie znaleziony.");
                        break;
                    case "5":
                        foreach (var p in baza.WyswietlWszystkie())
                        {
                            Console.WriteLine(p.PobierzDane());
                        }
                        break;
                    case "6":
                        Console.WriteLine("\n--- Wybierz typ pojazdu ---");
                        Console.WriteLine("1. Autobus");
                        Console.WriteLine("2. Ciezarowka");
                        Console.WriteLine("3. Dostawczak");
                        Console.WriteLine("4. Motocykl");
                        Console.WriteLine("5. Samochod osobowy");
                        Console.WriteLine("6. Samochod elektryczny");
                        Console.Write("Wybierz numer (1-6): ");
                        string wybor = Console.ReadLine() ?? "";
                        string typ = "";
                        if (wybor == "1")
                            typ = "Autobus";
                        else if (wybor == "2")
                            typ = "Ciezarowka";
                        else if (wybor == "3")
                            typ = "Dostawczak";
                        else if (wybor == "4")
                            typ = "Motocykl";
                        else if (wybor == "5")
                            typ = "SamochodOsobowy";
                        else if (wybor == "6")
                            typ = "SamochodElektryczny";
                        else
                        {
                            Console.WriteLine("Niepoprawny wybor.");
                            break;
                        }
                        List<IPojazd> pojazdy = baza.WyswietlWedlugTypu(typ);
                        if (pojazdy.Count == 0)
                        {
                            Console.WriteLine("Brak pojazdow tego typu.");
                        }
                        else
                        {
                            foreach (var p in pojazdy)
                            {
                                Console.WriteLine(p.PobierzDane());
                            }
                        }
                        break;
                    case "7":
                        baza.PokazStatystyki();
                        break;
                    case "8":
                        baza.EksportujDoSQL(bazaSQL);
                        break;
                    case "0":
                        dzialanie = false;
                        Console.WriteLine("Zamykanie programu.");
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybor.");
                        break;
                }
            }
        }
    }
}