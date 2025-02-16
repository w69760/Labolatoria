
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab03
{
    internal class Reviewer : Reader
    {
        public Reviewer(string firstName, string lastName, int wiek) : base(firstName, lastName, wiek)
        {

        }

        public void Wypisz()
        {
            Console.WriteLine($"Książki recenzowane przez: {this}");
            Random random = new Random();
            foreach(Book ksiazka in lista)
            {
                int ocena = random.Next(1, 11);
                Console.WriteLine($"Książka: {ksiazka} ocena: {ocena}/10");
            }
        }
    }
}