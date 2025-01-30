using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    public class Osoba
    {
        public string imie;
        public string nazwisko;
        public int wiek;

        public Osoba(string imie, string nazwisko, int wiek)
        {
            if (IsValidImie(imie))
            {
                this.imie = imie;
            }
            else
            {
                throw new ArgumentException("Imię musi mieć co najmniej 2 znaki");
            }

            if (IsValidNazwisko(nazwisko))
            {
                this.nazwisko = nazwisko;
            }
            else
            {
                throw new ArgumentException("Nazwisko musi mieć co najmniej 2 znaki");
            }
            
            if (IsValidWiek(wiek))
            {
                this.wiek = wiek;
            }
            else
            {
                throw new ArgumentException("Wiek musi być dodatni");
            }    

            
        }
        private bool IsValidImie(string imie)
        {
            return imie.Length >= 2;
        }
        private bool IsValidNazwisko(string nazwisko)
        {
            return nazwisko.Length >= 2;
        }
        private bool IsValidWiek(int wiek)
        {
            return wiek > 0;
        }
        public void WyswietlInformacje()
        {
            Console.WriteLine($"Imie: {imie}, nazwisko: {nazwisko}, wiek: {wiek}");
        }
    }
}
