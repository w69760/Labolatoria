using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04z2
{
    public class Osoba
    {
        string imie;
        string nazwisko;
        string pesel;

        public Osoba(string imie, string nazwisko, string pesel)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.pesel = pesel;
        }
        public virtual void SetFirstName(string imie)
        {
            this.imie = imie;
        }
        public virtual void SetLastName(string nazwisko)
        {
            this.nazwisko = nazwisko;
        }
        public virtual void SetPesel(string pesel)
        {
            if (pesel.Length != 11)
            {
                throw new ArgumentException("Nieprawidłowy PESEL");
            }

            this.pesel = pesel;
        }
        public virtual int GetAge()
        {
            if (pesel.Length != 11)
            {
                throw new InvalidOperationException("Numer PESEL jest nieprawidłowy.");
            }

            int year = int.Parse(pesel.Substring(0, 2));
            int month = int.Parse(pesel.Substring(2, 2));
            int day = int.Parse(pesel.Substring(4, 2));

            if (month > 20)
            {
                year += 2000;
                month -= 20;
            }
            else
            {
                year += 1900;
            }

            DateTime birthDate = new DateTime(year, month, day);
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now < birthDate.AddYears(age))
            {
                age--;
            }
            return age;
        }
        public virtual string GetGender()
        {
            if (pesel.Length != 11)
            {
                throw new InvalidOperationException("Numer PESEL jest nieprawidlowy.");
            }
            int genderIndicator = int.Parse(pesel[9].ToString());
            string gender;

            if (genderIndicator % 2 == 0)
            {
                gender = "kobieta";
            }
            else
            {
                gender = "mezczyzna";
            }
            return gender;
        }
        public virtual string GetEducationInfo()
        {
            return "Brak informacji o edukacji.";
        }

        public virtual string GetFullName()
        {
            return $"{imie} {nazwisko}";
        }

        public virtual bool CanGoAloneToHome()
        {
            return GetAge() >= 12;

        }
    }
}
