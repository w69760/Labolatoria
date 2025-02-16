using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    internal class Person
    {
        private string FirstName;
        private string LastName;
        private int Wiek;

        public Person(string FirstName, string LastName, int Wiek)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Wiek = Wiek;
        }

        public override string ToString()
        {
            return $"Osoba: {FirstName} {LastName}, wiek: {Wiek}";
        }

        public virtual void View()
        {
            Console.WriteLine(ToString());
        }

    }
}
