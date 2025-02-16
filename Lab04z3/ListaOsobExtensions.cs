using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab04z3
{
    public static class ListaOsobExtensions
    {
        public static void WypiszOsoby(this List<IOsoba> osoby)
        {
            foreach (var osoba in osoby)
            {
                if (osoba is IStudent student)
                {
                    Console.WriteLine(student.WypiszPelnaNazweIUczelnie());
                }
                else
                {
                    Console.WriteLine(osoba.ZwrocPelnaNazwe());
                }
            }
        }

        public static void PosortujOsobyPoNazwisku(this List<IOsoba> osoby)
        {
            osoby.Sort((a, b) => a.Nazwisko.CompareTo(b.Nazwisko));
        }
    }
}
