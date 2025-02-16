using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04z2
{
    internal class Nauczyciel : Uczen
    {
        public string tytulNaukowy;
        private List<Uczen> podwladniUczniowie;
        public Nauczyciel(string imie, string nazwisko, string pesel, string szkola, bool mozeSamWracacDoDomu, string tytulNaukowy) :
            base(imie, nazwisko, pesel, szkola, mozeSamWracacDoDomu)
        {
            this.tytulNaukowy = tytulNaukowy;
            this.podwladniUczniowie = new List<Uczen>();
        }
        public void AddStudent(Uczen uczen)
        {
            podwladniUczniowie.Add(uczen);
        }
        public void RemoveStudent(Uczen uczen)
        {
            podwladniUczniowie.Remove(uczen);
        }

        public void WhichStudentCanGoHomeAlone(DateTime dateToCheck)
        {
            Console.WriteLine($"Uczniowie, ktorzy mogą sami wrocic do domu w dniu {dateToCheck.ToShortDateString()}:");

            foreach (var uczen in podwladniUczniowie)
            {
                if (uczen.CanGoAloneToHome())
                {
                    Console.WriteLine($"{uczen.GetFullName()} (wiek: {uczen.GetAge()} lat)");
                }
            }
        }
    }
}
