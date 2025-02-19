using Projekt.ZarzadzaniePojazdami;

namespace Projekt.ZarzadzaniePojazdami.Klasy
{
    public class Ciezarowka : Pojazd
    {
        public double Ladownosc { get; set; }
        public double Dlugosc { get; set; }

        // Konstruktor dla nowego pojazdu
        public Ciezarowka(string marka, string model, int rok, string rejestracja, double ladownosc, double dlugosc)
            : base("Ciezarowka", marka, model, rok, rejestracja)
        {
            if (ladownosc <= 0)
                throw new ArgumentException("Ladownosc musi byc dodatnia");
            if (dlugosc <= 0)
                throw new ArgumentException("Dlugosc musi byc dodatnia");
            Ladownosc = ladownosc;
            Dlugosc = dlugosc;
        }

        // Konstruktor dla pojazdu wczytywanego z pliku
        public Ciezarowka(int id, string marka, string model, int rok, string rejestracja, DateTime dataDodania,
                          double ladownosc, double dlugosc)
            : base(id, "Ciezarowka", marka, model, rok, rejestracja, dataDodania)
        {
            if (ladownosc <= 0)
                throw new ArgumentException("Ladownosc musi byc dodatnia");
            if (dlugosc <= 0)
                throw new ArgumentException("Dlugosc musi byc dodatnia");
            Ladownosc = ladownosc;
            Dlugosc = dlugosc;
        }

        public override string PobierzDane()
        {
            return base.PobierzDane() + ", Ladownosc: " + Ladownosc + " t, Dlugosc: " + Dlugosc + " m";
        }

        public override string PobierzDaneCSV()
        {
            return base.PobierzDaneCSV() + ";" + Ladownosc + ";" + Dlugosc;
        }
    }
}