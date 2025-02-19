using Projekt.ZarzadzaniePojazdami;


namespace Projekt.ZarzadzaniePojazdami.Klasy
{
    public class Autobus : Pojazd
    {
        public int LiczbaMiejsc { get; set; }
        public double Dlugosc { get; set; }

        // Konstruktor dla nowego pojazdu
        public Autobus(string marka, string model, int rok, string rejestracja, int liczbaMiejsc, double dlugosc)
            : base("Autobus", marka, model, rok, rejestracja)
        {
            if (liczbaMiejsc <= 0)
                throw new ArgumentException("Liczba miejsc musi byc wieksza od 0");
            if (dlugosc <= 0)
                throw new ArgumentException("Dlugosc musi byc dodatnia");
            LiczbaMiejsc = liczbaMiejsc;
            Dlugosc = dlugosc;
        }

        // Konstruktor dla pojazdu wczytywanego z pliku
        public Autobus(int id, string marka, string model, int rok, string rejestracja, DateTime dataDodania,
                       int liczbaMiejsc, double dlugosc)
            : base(id, "Autobus", marka, model, rok, rejestracja, dataDodania)
        {
            if (liczbaMiejsc <= 0)
                throw new ArgumentException("Liczba miejsc musi byc wieksza od 0");
            if (dlugosc <= 0)
                throw new ArgumentException("Dlugosc musi byc dodatnia");
            LiczbaMiejsc = liczbaMiejsc;
            Dlugosc = dlugosc;
        }

        public override string PobierzDane()
        {
            return base.PobierzDane() + ", Miejsca: " + LiczbaMiejsc + ", Dlugosc: " + Dlugosc + " m";
        }

        public override string PobierzDaneCSV()
        {
            return base.PobierzDaneCSV() + ";" + LiczbaMiejsc + ";" + Dlugosc;
        }
    }
}