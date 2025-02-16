namespace Lab04z3
{
    public class Osoba : IOsoba
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public Osoba(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }

        public string ZwrocPelnaNazwe()
        {
            return $"{Imie} {Nazwisko}";
        }
    }
}
