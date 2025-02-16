using System;
using System.Collections.Generic;

namespace KalkulatorApp
{
    enum Operacja
    {
        Dodawanie,
        Odejmowanie,
        Mnozenie,
        Dzielenie
    }

    class Kalkulator
    {
        public static List<double> HistoriaWynikow { get; private set; } = new List<double>();

        public static double WykonajOperacje(double a, double b, Operacja operacja)
        {
            switch (operacja)
            {
                case Operacja.Dodawanie:
                    return a + b;
                case Operacja.Odejmowanie:
                    return a - b;
                case Operacja.Mnozenie:
                    return a * b;
                case Operacja.Dzielenie:
                    if (b == 0)
                        throw new DivideByZeroException("Nie można dzielić przez zero!");
                    return a / b;
                default:
                    throw new ArgumentException("Nieznana operacja");
            }
        }
    }
}