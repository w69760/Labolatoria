using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    internal class SamochodOsobowy : Samochod
    {
        public double Waga { get; private set; }
        public double PojemnoscSilnika { get; private set; }
        public int IloscOsob { get; private set; }

        public SamochodOsobowy() : base()
        {
            Console.WriteLine("Podaj wagę samochodu (w tonach):");
            Waga = double.Parse(Console.ReadLine());
            if (Waga < 2 || Waga > 4.5)
            {
                throw new ArgumentException("Waga musi być z przedziału 2 t - 4,5 t.");
            }

            Console.WriteLine("Podaj pojemność silnika (w litrach):");
            PojemnoscSilnika = double.Parse(Console.ReadLine());
            if (PojemnoscSilnika < 0.8 || PojemnoscSilnika > 3.0)
            {
                throw new ArgumentException("Pojemność silnika musi być z przedziału 0,8 - 3,0.");
            }

            Console.WriteLine("Podaj ilość osób:");
            IloscOsob = int.Parse(Console.ReadLine());
        }
        public SamochodOsobowy(string marka, string model, string nadwozie, string kolor, int rokProdukcji, int przebieg, double waga, double pojemnoscSilnika, int iloscOsob)
           : base(marka, model, nadwozie, kolor, rokProdukcji, przebieg)
        {
            if (waga < 2 || waga > 4.5)
            {
                throw new ArgumentException("Waga musi być z przedziału 2 t - 4,5 t.");
            }

            if (pojemnoscSilnika < 0.8 || pojemnoscSilnika > 3.0)
            {
                throw new ArgumentException("Pojemność silnika musi być z przedziału 0,8 - 3,0.");
            }

            Waga = waga;
            PojemnoscSilnika = pojemnoscSilnika;
            IloscOsob = iloscOsob;
        }
        public override void WyswietlInformacje()
        {
            base.WyswietlInformacje();
            Console.WriteLine($"Waga: {Waga} t, Pojemność silnika: {PojemnoscSilnika} L, Ilość osób: {IloscOsob}");
        }
    }
}
