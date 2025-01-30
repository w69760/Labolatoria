using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    public class Student
    {
        public string Imie { get;private set; }
        public string Nazwisko { get;private set; }
        private List<int> oceny;

        public Student(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            this.oceny = new List<int>();
        }
        public double SredniaOcen
        {
            get
            {
                return oceny.Any() ? oceny.Average() : 0;
            }
        }
        public void DodajOcene(int ocena)
        {
            if (ocena < 1 || ocena > 6)
            {
                throw new ArgumentException("Ocena musi być od 1 do 6");
            }
            
            oceny.Add(ocena);
        }
    }
}
