using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    public class Sumator
    {
        private int[] liczby;

        public int Suma()
        {
            return liczby.Sum();
        }
        public int SumaPodziel2()
        {
            int suma = 0;
            foreach (int liczba in liczby)
            {
                if (liczba % 2 == 0)
                {
                    suma += liczba;
                }
            }
            return suma;

        }
        public int IleElementow()
        {
            int ilosc = 0;
            foreach (int liczba in liczby)
            {
                ilosc++;
            }
            return ilosc;
        }
        public void Wypisanie()
        {
            foreach (int liczba in liczby)
            {
                Console.Write($"{liczba} ");
            }
            Console.WriteLine(" ");
        }
        public void MetodaIndeksy(int lowIndex, int highIndex)
        {
            if (lowIndex < 0)
            {
                lowIndex = 0;
            }
            if (highIndex >= liczby.Length)
            {
                highIndex = liczby.Length - 1;
            }

            for (int i = lowIndex; i <= highIndex; i++)
            {
                Console.WriteLine($"Indeks: {i}, liczba: {liczby[i]}");
            }
        }
        public Sumator(int[] liczby)
        {
            this.liczby = liczby;
        }
    }
}
