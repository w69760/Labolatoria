using System;
using System.IO;
using Projekt.ZarzadzaniePojazdami.Interfejsy;

namespace Projekt.ZarzadzaniePojazdami.Klasy
{
    public abstract class Pojazd : IPojazd
    {
        private static int _globalId = WczytajNajwyzszeIdZPliku();
        private const string SciezkaId = "pojazdy.txt";
        public int Id { get; private set; }
        public string Typ { get; protected set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int RokProdukcji { get; set; }
        public string NumerRejestracyjny { get; set; }
        public DateTime DataDodania { get; private set; }

        // Konstruktor dla nowego pojazdu - nadawanie unikalnego ID
        protected Pojazd(string typ, string marka, string model, int rok, string rejestracja)
        {
            if (string.IsNullOrWhiteSpace(typ))
                throw new ArgumentException("Typ nie moze byc pusty");
            if (string.IsNullOrWhiteSpace(marka))
                throw new ArgumentException("Marka nie moze byc pusta");
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("Model nie moze byc pusty");
            if (string.IsNullOrWhiteSpace(rejestracja))
                throw new ArgumentException("Rejestracja nie moze byc pusta");
            if (rok <= 0)
                throw new ArgumentException("Rok musi byc dodatni");

            Id = _globalId++;
            ZapiszIdDoPliku(_globalId);
            Typ = typ;
            Marka = marka;
            Model = model;
            RokProdukcji = rok;
            NumerRejestracyjny = rejestracja;
            DataDodania = DateTime.Now;
        }

        // Konstruktor dla pojazdu wczytywanego z pliku
        protected Pojazd(int id, string typ, string marka, string model, int rok, string rejestracja, DateTime data)
        {
            if (string.IsNullOrWhiteSpace(typ))
                throw new ArgumentException("Typ nie moze byc pusty");
            if (string.IsNullOrWhiteSpace(marka))
                throw new ArgumentException("Marka nie moze byc pusta");
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("Model nie moze byc pusty");
            if (string.IsNullOrWhiteSpace(rejestracja))
                throw new ArgumentException("Rejestracja nie moze byc pusta");
            if (rok <= 0)
                throw new ArgumentException("Rok musi byc dodatni");

            Id = id;
            Typ = typ;
            Marka = marka;
            Model = model;
            RokProdukcji = rok;
            NumerRejestracyjny = rejestracja;
            DataDodania = data;
        }
        // Odczyt najwyższego ID z pliku
        private static int WczytajNajwyzszeIdZPliku()
        {
            try
            {
                if (File.Exists(SciezkaId))
                {
                    var najwyzszeId = File.ReadLines(SciezkaId)
                        .Select(line => line.Split(';'))
                        .Where(parts => parts.Length > 0 && int.TryParse(parts[0], out _))
                        .Select(parts => int.Parse(parts[0]))
                        .DefaultIfEmpty(0)
                        .Max();
                    return najwyzszeId + 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Blad podczas odczytu ID z pliku: {ex.Message}");
            }
            return 1; // Start od 1, jeśli plik nie istnieje lub wystąpił błąd
        }
        public virtual string PobierzDane()
        {
            return "ID: " + Id + ", Typ: " + Typ + ", Marka: " + Marka + ", Model: " + Model + ", Rok: " + RokProdukcji +
                   ", Rejestracja: " + NumerRejestracyjny + ", Data dodania: " + DataDodania.ToString("dd.MM.yyyy");
        }

        public virtual string PobierzDaneCSV()
        {
            return Id + ";" + Typ + ";" + Marka + ";" + Model + ";" + RokProdukcji + ";" + NumerRejestracyjny + ";" + DataDodania.ToString("dd.MM.yyyy");
        }


        // Zapis ID do pliku
        private static void ZapiszIdDoPliku(int id)
        {
            const string sciezka = "id_counter.txt";
            try
            {
                File.WriteAllText(sciezka, id.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad podczas zapisu ID do pliku: " + ex.Message);
            }
        }
    }

}
