using System;
using System.Collections.Generic;

namespace Lab04z3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IOsoba> osoby = new List<IOsoba>
            {
                new Osoba("Jan", "Kowalski"),
                new Osoba("Anna", "Nowak"),
                new Osoba("Piotr", "Zieliński"),
                new Student("Kamil", "Adamski", "UJ", "Informatyka", 3, 5),
                new StudentWSIiZ("Marta", "Lewandowska", "Grafika", 2, 4)
            };

            Console.WriteLine("Przed sortowaniem:");
            osoby.WypiszOsoby();

            osoby.PosortujOsobyPoNazwisku();

            Console.WriteLine("\nPo sortowaniu:");
            osoby.WypiszOsoby();
        }
    }
}
