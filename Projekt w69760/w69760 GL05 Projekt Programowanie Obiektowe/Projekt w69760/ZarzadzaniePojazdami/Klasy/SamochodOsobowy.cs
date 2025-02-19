using Projekt.ZarzadzaniePojazdami;

namespace Projekt.ZarzadzaniePojazdami.Klasy
{
    public class SamochodOsobowy : Pojazd
    {
        public int LiczbaMiejsc { get; set; }

        // Konstruktor dla nowego samochodu osobowego
        public SamochodOsobowy(string marka, string model, int rok, string rejestracja, int liczbaMiejsc)
            : base("SamochodOsobowy", marka, model, rok, rejestracja)
        {
            if (liczbaMiejsc <= 0)
                throw new ArgumentException("Liczba miejsc musi byc wieksza od 0");
            LiczbaMiejsc = liczbaMiejsc;
        }

        // Konstruktor dla pojazdu wczytywanego z pliku
        public SamochodOsobowy(int id, string marka, string model, int rok, string rejestracja, DateTime dataDodania,
                               int liczbaMiejsc)
            : base(id, "SamochodOsobowy", marka, model, rok, rejestracja, dataDodania)
        {
            if (liczbaMiejsc <= 0)
                throw new ArgumentException("Liczba miejsc musi byc wieksza od 0");
            LiczbaMiejsc = liczbaMiejsc;
        }

        public override string PobierzDane()
        {
            return base.PobierzDane() + ", Liczba miejsc: " + LiczbaMiejsc;
        }

        public override string PobierzDaneCSV()
        {
            return base.PobierzDaneCSV() + ";" + LiczbaMiejsc;
        }
    }
}