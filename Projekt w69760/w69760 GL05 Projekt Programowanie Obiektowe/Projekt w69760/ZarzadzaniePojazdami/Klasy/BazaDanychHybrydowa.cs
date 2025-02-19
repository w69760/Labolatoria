using System;
using System.Collections.Generic;
using Projekt.ZarzadzaniePojazdami.Interfejsy;

namespace Projekt.ZarzadzaniePojazdami.Klasy
{
    public class BazaDanychHybrydowa : BazaDanychBase
    {
        private readonly BazaDanych _bazaPlikowa;
        private readonly BazaDanychSQL _bazaSQL;

        public BazaDanychHybrydowa(string sciezkaPliku, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(sciezkaPliku))
                throw new ArgumentException("Sciezka pliku nie moze byc pusta");
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Connection string nie moze byc pusty");

            _bazaPlikowa = new BazaDanych(sciezkaPliku);
            _bazaSQL = new BazaDanychSQL(connectionString);
        }

        public override void DodajPojazd(IPojazd pojazd)
        {
            if (pojazd == null)
            {
                Console.WriteLine("Niepoprawny pojazd.");
                return;
            }
            // Dodanie pojazdu do obu baz danych
            _bazaPlikowa.DodajPojazd(pojazd);
            _bazaSQL.DodajPojazd(pojazd);
        }

        public override void UsunPojazd(string rejestracja)
        {
            if (string.IsNullOrWhiteSpace(rejestracja))
            {
                Console.WriteLine("Niepoprawna rejestracja.");
                return;
            }
            // Usuniecie pojazdu z obu baz danych
            _bazaPlikowa.UsunPojazd(rejestracja);
            _bazaSQL.UsunPojazd(rejestracja);
        }

        public override void EdytujRejestracje(string staraRejestracja, string nowaRejestracja)
        {
            if (string.IsNullOrWhiteSpace(staraRejestracja) || string.IsNullOrWhiteSpace(nowaRejestracja))
            {
                Console.WriteLine("Niepoprawne dane rejestracyjne.");
                return;
            }
            // Aktualizacja rejestracji w obu bazach danych
            _bazaPlikowa.EdytujRejestracje(staraRejestracja, nowaRejestracja);
            _bazaSQL.EdytujRejestracje(staraRejestracja, nowaRejestracja);
        }

        public override IPojazd? WyszukajPojazd(string rejestracja)
        {
            if (string.IsNullOrWhiteSpace(rejestracja))
            {
                Console.WriteLine("Niepoprawna rejestracja.");
                return null;
            }
            // Wyszukiwanie pojazdu w bazie SQL, jesli nie istnieje, szuka w bazie plikowej
            IPojazd? pojazd = _bazaSQL.WyszukajPojazd(rejestracja);
            if (pojazd == null)
            {
                pojazd = _bazaPlikowa.WyszukajPojazd(rejestracja);
            }
            return pojazd;
        }

        public override List<IPojazd> WyswietlWszystkie()
        {
            List<IPojazd> pojazdySQL = _bazaSQL.WyswietlWszystkie();
            List<IPojazd> pojazdyPlikowe = _bazaPlikowa.WyswietlWszystkie();

            List<IPojazd> unikalnePojazdy = new List<IPojazd>();

            // Przechodzimy przez pojazdy z pliku i sprawdzamy, czy juz istnieja w bazie SQL
            foreach (IPojazd pojazd in pojazdyPlikowe)
            {
                bool istnieje = false;
                foreach (IPojazd pojazdSQL in pojazdySQL)
                {
                    if (pojazdSQL.Id == pojazd.Id)
                    {
                        istnieje = true;
                        break;
                    }
                }
                if (!istnieje)
                {
                    unikalnePojazdy.Add(pojazd);
                }
            }

            pojazdySQL.AddRange(unikalnePojazdy);
            return pojazdySQL;
        }

        public override List<IPojazd> WyswietlWedlugTypu(string typ)
        {
            if (string.IsNullOrWhiteSpace(typ))
            {
                Console.WriteLine("Niepoprawny typ.");
                return new List<IPojazd>();
            }
            List<IPojazd> pojazdySQL = _bazaSQL.WyswietlWedlugTypu(typ);
            List<IPojazd> pojazdyPlikowe = _bazaPlikowa.WyswietlWedlugTypu(typ);

            List<IPojazd> unikalnePojazdy = new List<IPojazd>();

            // Przechodzimy przez pojazdy z pliku i sprawdzamy, czy juz istnieja w bazie SQL
            foreach (IPojazd pojazd in pojazdyPlikowe)
            {
                bool istnieje = false;
                foreach (IPojazd pojazdSQL in pojazdySQL)
                {
                    if (pojazdSQL.Id == pojazd.Id)
                    {
                        istnieje = true;
                        break;
                    }
                }
                if (!istnieje)
                {
                    unikalnePojazdy.Add(pojazd);
                }
            }

            pojazdySQL.AddRange(unikalnePojazdy);
            return pojazdySQL;
        }

        public override void PokazStatystyki()
        {
            try
            {
                // Wyswietlanie statystyk dla obu baz danych
                _bazaSQL.PokazStatystyki();
                _bazaPlikowa.PokazStatystyki();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad podczas wyswietlania statystyk: " + ex.Message);
            }
        }

        public override void EksportujDoSQL(IBazaDanych sqlBaza)
        {
            try
            {
                List<IPojazd> pojazdy = WyswietlWszystkie();
                if (pojazdy.Count == 0)
                {
                    Console.WriteLine("Brak pojazdow do eksportu.");
                    return;
                }

                Console.WriteLine("Eksportowanie " + pojazdy.Count + " pojazdow do SQL...");

                int dodane = 0;
                int pominiete = 0;
                int bledne = 0;
                int rokMin = 1886;
                int rokMax = DateTime.Now.Year;

                foreach (IPojazd pojazd in pojazdy)
                {
                    // Sprawdzanie, czy pojazd juz istnieje w bazie SQL
                    if (sqlBaza.WyszukajPojazd(pojazd.NumerRejestracyjny) != null)
                    {
                        Console.WriteLine("Pojazd " + pojazd.NumerRejestracyjny + " juz istnieje w bazie SQL. Pominiecie.");
                        pominiete++;
                        continue;
                    }

                    // Sprawdzanie poprawnosci roku produkcji
                    if (pojazd.RokProdukcji < rokMin || pojazd.RokProdukcji > rokMax)
                    {
                        Console.WriteLine("Blad: Rok " + pojazd.RokProdukcji + " jest niepoprawny dla " + pojazd.NumerRejestracyjny + ". Pominiecie.");
                        bledne++;
                        continue;
                    }

                    // Dodanie pojazdu do bazy SQL
                    sqlBaza.DodajPojazd(pojazd);
                    dodane++;
                }

                Console.WriteLine("Eksport zakonczony! Dodano: " + dodane + ", Pominiecie: " + pominiete + ", Bledne dane: " + bledne);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad podczas eksportu do SQL: " + ex.Message);
            }
        }
    }
}