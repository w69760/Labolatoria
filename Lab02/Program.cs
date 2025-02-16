namespace Lab02
{
    public class Program
    {
        public static void Main(string[] args)
        {   //z1
            Osoba wojciech = new Osoba("Wojciech", "Armata", 67);
            wojciech.WyswietlInformacje();

            //z2
            BankAccount konto = new BankAccount("Wojciech", 1000);
            konto.Wplata(100);
            konto.Wyplata(1000);

            //z3
            Student student = new Student("Jerzy", "Gołąb");
            student.DodajOcene(4);
            student.DodajOcene(2);

            //z4
            Licz jeden = new Licz(1);
            Licz dwa = new Licz(2);
            jeden.Dodaj(5);
            jeden.Wyswietl();
            dwa.Wyswietl();
            dwa.Odejmij(10);
            dwa.Wyswietl();

            //z5
            Sumator sumator = new Sumator(new int[] { 1, 5, 6, 2, 2, 5, 6 });
            Console.WriteLine(sumator.Suma());
            Console.WriteLine(sumator.IleElementow());
            sumator.Wypisanie();
            sumator.MetodaIndeksy(-2, 10);
        }

    }

}