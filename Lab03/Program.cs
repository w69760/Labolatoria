using System.Collections.Generic;
using System.ComponentModel;

namespace Lab03
{
    class Program
    {
        static void Main(string[] args)
        {
            //autorzy
            Person osoba1 = new Person("Wojciech", "Armata", 20);
            Person osoba2 = new Person("Radek", "Batata", 21);
            Person osoba3 = new Person("Szymon", "Pomelo", 22);
            osoba1.View();

            Book ency = new Book("Encyklopedia", osoba1, "2014");
            Book slownik = new Book("Slownik", osoba2, "2002");
            Book poradnik = new Book("Poradnik", osoba3, "2009");
            ency.View();
            //czytelnicy
            Reader czytelnik1 = new Reader("Michał", "Wojak", 21);
            Reader czytelnik2 = new Reader("Pawe", "Gawel", 19);
            czytelnik1.Lista.AddRange(new List<Book> { ency, slownik, poradnik });
            czytelnik2.Lista.AddRange(new List<Book> { ency });

            czytelnik1.ViewBook();
            czytelnik2.ViewBook();
            czytelnik1.View();

            Person o = new Reader("Jaroslaw", "Polskezbaw", 60);
            o.View();

            //recenzenci
            Reviewer recenzent1 = new Reviewer("Marcin", "Pomada", 25);
            Reviewer recenzent2 = new Reviewer("Cezary", "Baryka", 69);
            recenzent1.Lista.AddRange(new List<Book> { poradnik, ency, slownik });
            recenzent2.Lista.AddRange(new List<Book> { ency });
            recenzent1.Wypisz();
            recenzent2.Wypisz();
            Console.WriteLine("--------------");
            List<Person> osoby = new List<Person>();
            osoby.AddRange(new List<Person> { czytelnik1, czytelnik2, recenzent1, recenzent2 });
            foreach (Person osoba in osoby)
            {
                osoba.View();
            }
            DocumentaryBook dokument = new DocumentaryBook("Dokument", osoba1, "2002", "Opis książki dokumentalnej");
            AdventureBook przygodowa = new AdventureBook("Przygodowka", osoba2, "2020", "Opis książki przygodowej");

            czytelnik2.Lista.Add(przygodowa);
            Console.WriteLine("----------");
            czytelnik2.ViewBook();


            //z2
            try
            {
                // Tworzenie obiektu klasy SamochodOsobowy (z danych użytkownika)
                Console.WriteLine("Tworzenie samochodu osobowego:");
                SamochodOsobowy samochodOsobowy = new SamochodOsobowy();
                samochodOsobowy.WyswietlInformacje();

                // Tworzenie obiektu klasy Samochod (z parametrami)
                Console.WriteLine("\nTworzenie samochodu z parametrami:");
                Samochod samochod1 = new Samochod("Toyota", "Corolla", "Sedan", "Biały", 2020, 50000);
                samochod1.WyswietlInformacje();

                // Tworzenie obiektu klasy Samochod (z danych użytkownika)
                Console.WriteLine("\nTworzenie samochodu (z danych użytkownika):");
                Samochod samochod2 = new Samochod();
                samochod2.WyswietlInformacje();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }

        }
    }
}