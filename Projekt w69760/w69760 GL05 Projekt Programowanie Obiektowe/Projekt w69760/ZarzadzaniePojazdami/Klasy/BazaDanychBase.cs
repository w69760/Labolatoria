using System;
using System.Collections.Generic;
using Projekt.ZarzadzaniePojazdami.Interfejsy;

namespace Projekt.ZarzadzaniePojazdami.Klasy
{
    public abstract class BazaDanychBase : IBazaDanych
    {
        public abstract void DodajPojazd(IPojazd pojazd);
        public abstract void UsunPojazd(string rejestracja);
        public abstract void EdytujRejestracje(string staraRejestracja, string nowaRejestracja);
        public abstract IPojazd? WyszukajPojazd(string rejestracja);
        public abstract List<IPojazd> WyswietlWszystkie();
        public abstract List<IPojazd> WyswietlWedlugTypu(string typ);
        public abstract void PokazStatystyki();

        public virtual void EksportujDoSQL(IBazaDanych sqlBaza)
        {
            Console.WriteLine("Eksport do SQL nie jest obslugiwany w tej bazie.");
        }

        public void DodajNowyPojazd()
        {
            try
            {
                Console.WriteLine("\n--- Wybierz typ pojazdu ---");
                Console.WriteLine("1. Autobus");
                Console.WriteLine("2. Ciezarowka");
                Console.WriteLine("3. Dostawczak");
                Console.WriteLine("4. Motocykl");
                Console.WriteLine("5. Samochod osobowy");
                Console.WriteLine("6. Samochod elektryczny");

                string wybor = PobierzWartosc("Wybierz numer (1-6): ", "Niepoprawny wybor.");
                string marka = PobierzWartosc("Marka: ", "Marka nie moze byc pusta.");
                string model = PobierzWartosc("Model: ", "Model nie moze byc pusty.");
                int rok = PobierzWartoscInt("Rok produkcji: ", "Niepoprawny rok.");
                string rejestracja = PobierzWartosc("Rejestracja: ", "Niepoprawny numer rejestracyjny.");

                IPojazd pojazd;
                switch (wybor)
                {
                    case "1":
                        int miejsca = PobierzWartoscInt("Liczba miejsc: ", "Musi byc wieksza od 0.");
                        double dlugosc = PobierzWartoscDouble("Dlugosc (m): ", "Musi byc dodatnia.");
                        pojazd = new Autobus(marka, model, rok, rejestracja, miejsca, dlugosc);
                        break;
                    case "2":
                        double ladownoscC = PobierzWartoscDouble("Ladownosc (t): ", "Musi byc dodatnia.");
                        double dlugoscC = PobierzWartoscDouble("Dlugosc (m): ", "Musi byc dodatnia.");
                        pojazd = new Ciezarowka(marka, model, rok, rejestracja, ladownoscC, dlugoscC);
                        break;
                    case "3":
                        double ladownoscD = PobierzWartoscDouble("Ladownosc (t): ", "Musi byc dodatnia.");
                        pojazd = new Dostawczak(marka, model, rok, rejestracja, ladownoscD);
                        break;
                    case "4":
                        int pojemnoscSilnika = PobierzWartoscInt("Pojemnosc silnika (ccm): ", "Musi byc wieksza od 50.");
                        pojazd = new Motocykl(marka, model, rok, rejestracja, pojemnoscSilnika);
                        break;
                    case "5":
                        int miejscaS = PobierzWartoscInt("Liczba miejsc: ", "Musi byc wieksza od 0.");
                        pojazd = new SamochodOsobowy(marka, model, rok, rejestracja, miejscaS);
                        break;
                    case "6":
                        int miejscaE = PobierzWartoscInt("Liczba miejsc: ", "Musi byc wieksza od 0.");
                        double bateria = PobierzWartoscDouble("Pojemnosc baterii (kWh): ", "Musi byc dodatnia.");
                        int zasieg = PobierzWartoscInt("Zasieg (km): ", "Musi byc wieksza od 0.");
                        pojazd = new SamochodElektryczny(marka, model, rok, rejestracja, miejscaE, bateria, zasieg);
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybor.");
                        return;
                }
                DodajPojazd(pojazd);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystapil blad: " + ex.Message);
            }
        }

        protected string PobierzWartosc(string komunikat, string blad)
        {
            while (true)
            {
                Console.Write(komunikat);
                string wartosc = Console.ReadLine()?.Trim() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(wartosc))
                    return wartosc;
                Console.WriteLine(blad);
            }
        }

        protected int PobierzWartoscInt(string komunikat, string blad)
        {
            while (true)
            {
                Console.Write(komunikat);
                string input = Console.ReadLine() ?? "";
                int liczba;
                if (int.TryParse(input, out liczba) && liczba > 0)
                    return liczba;
                Console.WriteLine(blad);
            }
        }

        protected double PobierzWartoscDouble(string komunikat, string blad)
        {
            while (true)
            {
                Console.Write(komunikat);
                string input = Console.ReadLine() ?? "";
                double liczba;
                if (double.TryParse(input, out liczba) && liczba > 0)
                    return liczba;
                Console.WriteLine(blad);
            }
        }
    }
}