using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    public class Licz
    {
        private int value;

        public void Dodaj(int parametr)
        {
            value += parametr;
        }
        public void Odejmij(int parametr)
        {
            value -= parametr;
        }
        public void Wyswietl()
        {
            Console.WriteLine(value);
        }

        public Licz(int value)
        {
            this.value = value;
        }

    }
}
