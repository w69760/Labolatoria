using System.Collections.Generic;

namespace Projekt.ZarzadzaniePojazdami.Interfejsy
{
    public interface IBazaDanych
    {
        void DodajNowyPojazd(); // Tworzy i dodaje nowy pojazd na podstawie danych użytkownika
        void DodajPojazd(IPojazd pojazd);
        void UsunPojazd(string rejestracja);
        void EdytujRejestracje(string staraRejestracja, string nowaRejestracja);
        IPojazd? WyszukajPojazd(string rejestracja);
        List<IPojazd> WyswietlWszystkie();
        List<IPojazd> WyswietlWedlugTypu(string typ);
        void PokazStatystyki();
        void EksportujDoSQL(IBazaDanych sqlBaza); // Eksport danych do innej bazy
    }
}
