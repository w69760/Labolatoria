namespace Lab04z3
{
    public interface IStudent : IOsoba
    {
        string Uczelnia { get; set; }
        string Kierunek { get; set; }
        int Rok { get; set; }
        int Semestr { get; set; }

        string WypiszPelnaNazweIUczelnie();
    }
}
