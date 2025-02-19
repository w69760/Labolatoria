using System;
using System.Collections.Generic;
using System.IO;
using Projekt.ZarzadzaniePojazdami.Interfejsy;

namespace Projekt.ZarzadzaniePojazdami.Klasy
{
    public class BazaDanych : BazaDanychBase
    {
        private readonly string _sciezkaPliku;

        public BazaDanych(string sciezkaPliku)
        {
            if (string.IsNullOrWhiteSpace(sciezkaPliku))
                throw new ArgumentException("Sciezka pliku nie moze byc pusta");
            _sciezkaPliku = sciezkaPliku;

            try
            {
                // Tworzy plik, jesli nie istnieje
                if (!File.Exists(_sciezkaPliku))
                {
                    File.Create(_sciezkaPliku).Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad podczas tworzenia pliku: " + ex.Message);
            }
        }

        public override void DodajPojazd(IPojazd pojazd)
        {
            if (pojazd == null)
            {
                Console.WriteLine("Niepoprawny pojazd.");
                return;
            }
            try
            {
                // Dopisuje nowy pojazd do pliku
                File.AppendAllLines(_sciezkaPliku, new string[] { pojazd.PobierzDaneCSV() });
                Console.WriteLine("Pojazd zapisany w pliku.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad zapisu do pliku: " + ex.Message);
            }
        }

        public override void UsunPojazd(string rejestracja)
        {
            if (string.IsNullOrWhiteSpace(rejestracja))
            {
                Console.WriteLine("Niepoprawna rejestracja.");
                return;
            }
            try
            {
                // Wczytuje zawartosc pliku
                List<string> linie = new List<string>(File.ReadAllLines(_sciezkaPliku));
                List<string> noweLinie = new List<string>();

                bool znaleziono = false;

                // Przeglada kazda linie w celu znalezienia pojazdu do usuniecia
                foreach (string linia in linie)
                {
                    string[] pola = linia.Split(';');
                    if (pola.Length > 5 && pola[5] == rejestracja)
                    {
                        znaleziono = true;
                    }
                    else
                    {
                        noweLinie.Add(linia);
                    }
                }

                // Aktualizuje plik, jesli znaleziono pojazd
                if (znaleziono)
                {
                    File.WriteAllLines(_sciezkaPliku, noweLinie);
                    Console.WriteLine("Pojazd usuniety.");
                }
                else
                {
                    Console.WriteLine("Pojazd nie zostal znaleziony.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad podczas usuwania pojazdu: " + ex.Message);
            }
        }

        public override void EdytujRejestracje(string staraRejestracja, string nowaRejestracja)
        {
            if (string.IsNullOrWhiteSpace(staraRejestracja) || string.IsNullOrWhiteSpace(nowaRejestracja))
            {
                Console.WriteLine("Niepoprawne dane rejestracyjne.");
                return;
            }
            try
            {
                // Wczytuje plik do listy
                List<string> linie = new List<string>(File.ReadAllLines(_sciezkaPliku));
                bool zmieniono = false;

                // Szuka pojazdu o podanej rejestracji i aktualizuje ja
                for (int i = 0; i < linie.Count; i++)
                {
                    string[] pola = linie[i].Split(';');
                    if (pola.Length > 5 && pola[5] == staraRejestracja)
                    {
                        pola[5] = nowaRejestracja;
                        linie[i] = string.Join(";", pola);
                        zmieniono = true;
                        break;
                    }
                }

                // Zapisuje zmiany w pliku
                if (zmieniono)
                {
                    File.WriteAllLines(_sciezkaPliku, linie);
                    Console.WriteLine("Rejestracja zaktualizowana.");
                }
                else
                {
                    Console.WriteLine("Nie znaleziono pojazdu.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad podczas edycji rejestracji: " + ex.Message);
            }
        }

        public override IPojazd? WyszukajPojazd(string rejestracja)
        {
            if (string.IsNullOrWhiteSpace(rejestracja))
            {
                Console.WriteLine("Niepoprawna rejestracja.");
                return null;
            }
            try
            {
                // Wczytuje plik i szuka pojazdu
                string[] linie = File.ReadAllLines(_sciezkaPliku);

                foreach (string linia in linie)
                {
                    string[] pola = linia.Split(';');
                    if (pola.Length > 5 && pola[5] == rejestracja)
                    {
                        return ZamienLinieNaPojazd(linia);
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad wyszukiwania pojazdu: " + ex.Message);
                return null;
            }
        }

        public override System.Collections.Generic.List<IPojazd> WyswietlWszystkie()
        {
            System.Collections.Generic.List<IPojazd> pojazdy = new System.Collections.Generic.List<IPojazd>();
            try
            {
                // Sprawdza, czy plik istnieje
                if (!File.Exists(_sciezkaPliku)) return pojazdy;

                // Wczytuje plik i konwertuje linie na pojazdy
                string[] linie = File.ReadAllLines(_sciezkaPliku);
                foreach (string linia in linie)
                {
                    IPojazd? pojazd = ZamienLinieNaPojazd(linia);
                    if (pojazd != null)
                    {
                        pojazdy.Add(pojazd);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad wczytywania danych z pliku: " + ex.Message);
            }
            return pojazdy;
        }

        public override System.Collections.Generic.List<IPojazd> WyswietlWedlugTypu(string typ)
        {
            System.Collections.Generic.List<IPojazd> pojazdyWedlugTypu = new System.Collections.Generic.List<IPojazd>();
            System.Collections.Generic.List<IPojazd> wszystkiePojazdy = WyswietlWszystkie();

            // Szuka pojazdow pasujacych do danego typu
            foreach (IPojazd pojazd in wszystkiePojazdy)
            {
                if (string.Equals(pojazd.Typ, typ, System.StringComparison.OrdinalIgnoreCase))
                {
                    pojazdyWedlugTypu.Add(pojazd);
                }
            }

            return pojazdyWedlugTypu;
        }

        public override void PokazStatystyki()
        {
            try
            {
                System.Collections.Generic.Dictionary<string, int> statystyki = new System.Collections.Generic.Dictionary<string, int>();

                // Liczy pojazdy wedlug typu
                System.Collections.Generic.List<IPojazd> pojazdy = WyswietlWszystkie();
                foreach (IPojazd pojazd in pojazdy)
                {
                    if (statystyki.ContainsKey(pojazd.Typ))
                    {
                        statystyki[pojazd.Typ]++;
                    }
                    else
                    {
                        statystyki[pojazd.Typ] = 1;
                    }
                }

                // Wyswietla statystyki
                foreach (var wpis in statystyki)
                {
                    Console.WriteLine(wpis.Key + ": " + wpis.Value + " pojazdow");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad podczas wyswietlania statystyk: " + ex.Message);
            }
        }

        private IPojazd? ZamienLinieNaPojazd(string linia)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(linia))
                {
                    return null;
                }

                string[] pola = linia.Split(';');
                if (pola.Length < 7)
                {
                    return null;
                }

                int id = int.Parse(pola[0]);
                string typ = pola[1];
                string marka = pola[2];
                string model = pola[3];
                int rok = int.Parse(pola[4]);
                string rejestracja = pola[5];
                System.DateTime dataDodania = System.DateTime.ParseExact(pola[6], "dd.MM.yyyy", null);

                // Tworzy obiekt pojazdu na podstawie typu
                if (typ == "Autobus")
                {
                    return new Autobus(id, marka, model, rok, rejestracja, dataDodania, int.Parse(pola[7]), double.Parse(pola[8]));
                }
                if (typ == "Ciezarowka")
                {
                    return new Ciezarowka(id, marka, model, rok, rejestracja, dataDodania, double.Parse(pola[7]), double.Parse(pola[8]));
                }
                if (typ == "Dostawczak")
                {
                    return new Dostawczak(id, marka, model, rok, rejestracja, dataDodania, double.Parse(pola[7]));
                }
                if (typ == "Motocykl")
                {
                    return new Motocykl(id, marka, model, rok, rejestracja, dataDodania, int.Parse(pola[7]));
                }
                if (typ == "SamochodOsobowy")
                {
                    return new SamochodOsobowy(id, marka, model, rok, rejestracja, dataDodania, int.Parse(pola[7]));
                }
                if (typ == "SamochodElektryczny")
                {
                    return new SamochodElektryczny(id, marka, model, rok, rejestracja, dataDodania, int.Parse(pola[7]), double.Parse(pola[8]), int.Parse(pola[9]));
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad parsowania linii: " + ex.Message);
                return null;
            }
        }
    }

}
        
    

