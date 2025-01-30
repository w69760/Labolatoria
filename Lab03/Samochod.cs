using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    internal class Samochod
    {
        public string Marka { get; private set; }
        public string Model { get; private set; }
        public string Nadwozie { get; private set; }
        public string Kolor { get; private set; }
        public int RokProdukcji { get; private set; }
        private int przebieg;

        public int Przebieg
        {
            get { return przebieg; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Przebieg nie może być ujemny.");
                }
                przebieg = value;
            }
        }

        
        public Samochod()
        {
            Console.WriteLine("Podaj markę samochodu:");
            Marka = Console.ReadLine();

            Console.WriteLine("Podaj model samochodu:");
            Model = Console.ReadLine();

            Console.WriteLine("Podaj typ nadwozia:");
            Nadwozie = Console.ReadLine();

            Console.WriteLine("Podaj kolor samochodu:");
            Kolor = Console.ReadLine();

            Console.WriteLine("Podaj rok produkcji:");
            RokProdukcji = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj przebieg samochodu:");
            Przebieg = int.Parse(Console.ReadLine());
        }


      
        public Samochod(string marka, string model, string nadwozie, string kolor, int rokProdukcji, int przebieg)
        {
            Marka = marka;
            Model = model;
            Nadwozie = nadwozie;
            Kolor = kolor;
            RokProdukcji = rokProdukcji;
            Przebieg = przebieg;
        }

      
        public virtual void WyswietlInformacje()
        {
            Console.WriteLine($"Marka: {Marka}, Model: {Model}, Nadwozie: {Nadwozie}, Kolor: {Kolor}, Rok produkcji: {RokProdukcji}, Przebieg: {Przebieg} km");
        }
    }
}
