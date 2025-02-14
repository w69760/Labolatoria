using System;
using System.Collections.Generic;

namespace SklepApp
{
    enum StatusZamowienia
    {
        Oczekujace,
        Przyjete,
        Zrealizowane,
        Anulowane
    }

    class Sklep
    {
        private Dictionary<int, (StatusZamowienia, List<string>)> zamowienia = new Dictionary<int, (StatusZamowienia, List<string>)>();

        public void DodajZamowienie(int numer, List<string> produkty)
        {
            zamowienia[numer] = (StatusZamowienia.Oczekujace, produkty);
        }

        public void ZmienStatusZamowienia(int numer, StatusZamowienia nowyStatus)
        {
            if (!zamowienia.ContainsKey(numer))
                throw new KeyNotFoundException("Nie znaleziono zamówienia o podanym numerze.");

            if (zamowienia[numer].Item1 == nowyStatus)
                throw new ArgumentException("Nowy status jest taki sam jak obecny.");

            zamowienia[numer] = (nowyStatus, zamowienia[numer].Item2);
        }

        public void WyswietlZamowienia()
        {
            foreach (var zamowienie in zamowienia)
            {
                Console.WriteLine($"Zamówienie {zamowienie.Key}: Status - {zamowienie.Value.Item1}, Produkty: {string.Join(", ", zamowienie.Value.Item2)}");
            }
        }
    }
}
