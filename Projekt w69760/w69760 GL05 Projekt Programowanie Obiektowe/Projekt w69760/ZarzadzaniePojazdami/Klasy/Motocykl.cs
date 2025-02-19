using Projekt.ZarzadzaniePojazdami;

namespace Projekt.ZarzadzaniePojazdami.Klasy
{
    public class Motocykl : Pojazd
    {
        public int PojemnoscSilnika { get; set; }

        // Konstruktor dla nowego motocykla
        public Motocykl(string marka, string model, int rok, string rejestracja, int pojemnoscSilnika)
            : base("Motocykl", marka, model, rok, rejestracja)
        {
            if (pojemnoscSilnika < 50)
                throw new ArgumentException("Pojemnosc silnika musi byc wieksza lub rowna 50");
            PojemnoscSilnika = pojemnoscSilnika;
        }

        // Konstruktor dla motocykla wczytywanego z pliku
        public Motocykl(int id, string marka, string model, int rok, string rejestracja, DateTime dataDodania,
                        int pojemnoscSilnika)
            : base(id, "Motocykl", marka, model, rok, rejestracja, dataDodania)
        {
            if (pojemnoscSilnika < 50)
                throw new ArgumentException("Pojemnosc silnika musi byc wieksza lub rowna 50");
            PojemnoscSilnika = pojemnoscSilnika;
        }

        public override string PobierzDane()
        {
            return base.PobierzDane() + ", Pojemnosc silnika: " + PojemnoscSilnika + " ccm";
        }

        public override string PobierzDaneCSV()
        {
            return base.PobierzDaneCSV() + ";" + PojemnoscSilnika;
        }
    }
}