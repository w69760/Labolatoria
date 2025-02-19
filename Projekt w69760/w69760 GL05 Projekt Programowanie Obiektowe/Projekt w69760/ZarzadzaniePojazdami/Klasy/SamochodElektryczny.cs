using System;
using Projekt.ZarzadzaniePojazdami;

namespace Projekt.ZarzadzaniePojazdami.Klasy
{
    public class SamochodElektryczny : SamochodOsobowy
    {
        public double PojemnoscBaterii { get; set; }
        public int Zasieg { get; set; }

        // Konstruktor dla nowego pojazdu
        public SamochodElektryczny(string marka, string model, int rok, string rejestracja,
                                   int liczbaMiejsc, double pojemnoscBaterii, int zasieg)
            : base(marka, model, rok, rejestracja, liczbaMiejsc)
        {
            if (pojemnoscBaterii <= 0)
                throw new ArgumentException("Pojemnosc baterii musi byc dodatnia");
            if (zasieg <= 0)
                throw new ArgumentException("Zasieg musi byc wiekszy od 0");
            Typ = "SamochodElektryczny";
            PojemnoscBaterii = pojemnoscBaterii;
            Zasieg = zasieg;
        }

        // Konstruktor dla pojazdu wczytywanego z pliku
        public SamochodElektryczny(int id, string marka, string model, int rok, string rejestracja, DateTime dataDodania,
                                   int liczbaMiejsc, double pojemnoscBaterii, int zasieg)
            : base(id, marka, model, rok, rejestracja, dataDodania, liczbaMiejsc)
        {
            if (pojemnoscBaterii <= 0)
                throw new ArgumentException("Pojemnosc baterii musi byc dodatnia");
            if (zasieg <= 0)
                throw new ArgumentException("Zasieg musi byc wiekszy od 0");
            Typ = "SamochodElektryczny";
            PojemnoscBaterii = pojemnoscBaterii;
            Zasieg = zasieg;
        }

        public override string PobierzDane()
        {
            return base.PobierzDane() + ", Pojemnosc baterii: " + PojemnoscBaterii + " kWh, Zasieg: " + Zasieg + " km";
        }

        public override string PobierzDaneCSV()
        {
            return base.PobierzDaneCSV() + ";" + PojemnoscBaterii + ";" + Zasieg;
        }
    }
}