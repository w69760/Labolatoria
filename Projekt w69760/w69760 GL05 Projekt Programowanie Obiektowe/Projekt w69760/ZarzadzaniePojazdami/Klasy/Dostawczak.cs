using Projekt.ZarzadzaniePojazdami;

namespace Projekt.ZarzadzaniePojazdami.Klasy
{
    public class Dostawczak : Pojazd
    {
        public double Ladownosc { get; set; }

        // Konstruktor dla nowego pojazdu
        public Dostawczak(string marka, string model, int rok, string rejestracja, double ladownosc)
            : base("Dostawczak", marka, model, rok, rejestracja)
        {
            if (ladownosc <= 0)
                throw new ArgumentException("Ladownosc musi byc dodatnia");
            Ladownosc = ladownosc;
        }

        // Konstruktor dla pojazdu wczytywanego z pliku
        public Dostawczak(int id, string marka, string model, int rok, string rejestracja, DateTime dataDodania,
                          double ladownosc)
            : base(id, "Dostawczak", marka, model, rok, rejestracja, dataDodania)
        {
            if (ladownosc <= 0)
                throw new ArgumentException("Ladownosc musi byc dodatnia");
            Ladownosc = ladownosc;
        }

        public override string PobierzDane()
        {
            return base.PobierzDane() + ", Ladownosc: " + Ladownosc + " t";
        }

        public override string PobierzDaneCSV()
        {
            return base.PobierzDaneCSV() + ";" + Ladownosc;
        }
    }
}