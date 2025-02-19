namespace Projekt.ZarzadzaniePojazdami.Interfejsy
{
    public interface IPojazd
    {
        int Id { get; }
        string Typ { get; }
        string Marka { get; set; }
        string Model { get; set; }
        int RokProdukcji { get; set; }
        string NumerRejestracyjny { get; set; }
        DateTime DataDodania { get; } // Data dodania pojazdu do bazy

        string PobierzDane();    // Zwraca sformatowane informacje o pojeździe
        string PobierzDaneCSV(); // Formatuje dane do zapisu w CSV
    }
}
