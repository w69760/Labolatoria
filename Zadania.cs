using System;

class Zadania
{
    static void Main(string[] args)
    {
        int wybor;
        do
        {
            Console.WriteLine("Wybierz zadanie:");
            Console.WriteLine("1 - Delta i pierwiastki trójmianu kwadratowego");
            Console.WriteLine("2 - Kalkulator");
            Console.WriteLine("3 - Operacje na tablicy");
            Console.WriteLine("4 - Operacje na elementach tablicy");
            Console.WriteLine("5 - Wyświetlanie liczb z wyłączeniami");
            Console.WriteLine("6 - Pętla nieskończona");
            Console.WriteLine("7 - Sortowanie liczb");
            Console.WriteLine("0 - Wyjście");
            wybor = int.Parse(Console.ReadLine());

            switch (wybor)
            {
                case 1:
                    DeltaIPierwiastki();
                    break;
                case 2:
                    Kalkulator();
                    break;
                case 3:
                    OperacjeNaTablicy();
                    break;
                case 4:
                    OperacjeNaElementachTablicy();
                    break;
                case 5:
                    WyswietlLiczbyZWyjatkami();
                    break;
                case 6:
                    PetlaNieskonczona();
                    break;
                case 7:
                    SortowanieLiczb();
                    break;
                default:
                    if (wybor != 0)
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                    break;
            }
        } while (wybor != 0);
    }

    // Zadanie 1
    static void DeltaIPierwiastki()
    {
        Console.WriteLine("Podaj współczynnik a:");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Podaj współczynnik b:");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Podaj współczynnik c:");
        double c = double.Parse(Console.ReadLine());

        double delta = b * b - 4 * a * c;
        Console.WriteLine($"Delta wynosi: {delta}");

        if (delta > 0)
        {
            double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
            Console.WriteLine($"Pierwiastki to: x1 = {x1}, x2 = {x2}");
        }
        else if (delta == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine($"Pierwiastek podwójny: x = {x}");
        }
        else
        {
            Console.WriteLine("Brak rzeczywistych pierwiastków.");
        }
    }

    // Zadanie 2
    static void Kalkulator()
    {
        int wybor;
        do
        {
            Console.WriteLine("1-Suma, 2-Różnica, 3-Iloczyn, 4-Iloraz, 5-Potęga, 6-Pierwiastek, 7-Funkcje trygonometryczne, 0-Wyjście");
            wybor = int.Parse(Console.ReadLine());

            if (wybor == 0) break;

            if (wybor == 6 || wybor == 7)
            {
                Console.WriteLine("Podaj liczbę a:");
                double liczba = double.Parse(Console.ReadLine());
                ObliczJednoArgumentowe(wybor, liczba);
            }
            else
            {
                Console.WriteLine("Podaj liczbę a:");
                double a = double.Parse(Console.ReadLine());
                Console.WriteLine("Podaj liczbę b:");
                double b = double.Parse(Console.ReadLine());
                ObliczDwaArgumenty(wybor, a, b);
            }
        } while (wybor != 0);
    }

    static void ObliczJednoArgumentowe(int wybor, double liczba)
    {
        if (wybor == 6)
        {
            if (liczba >= 0)
                Console.WriteLine($"Pierwiastek: {Math.Sqrt(liczba)}");
            else
                Console.WriteLine("Nie można obliczyć pierwiastka z liczby ujemnej.");
        }
        else if (wybor == 7)
        {
            Console.WriteLine($"Sin: {Math.Sin(liczba)}");
            Console.WriteLine($"Cos: {Math.Cos(liczba)}");
            Console.WriteLine($"Tan: {Math.Tan(liczba)}");
        }
    }

    static void ObliczDwaArgumenty(int wybor, double a, double b)
    {
        switch (wybor)
        {
            case 1:
                Console.WriteLine($"Suma: {a + b}");
                break;
            case 2:
                Console.WriteLine($"Różnica: {a - b}");
                break;
            case 3:
                Console.WriteLine($"Iloczyn: {a * b}");
                break;
            case 4:
                if (b != 0)
                    Console.WriteLine($"Iloraz: {a / b}");
                else
                    Console.WriteLine("Nie można dzielić przez zero.");
                break;
            case 5:
                Console.WriteLine($"Potęga: {Math.Pow(a, b)}");
                break;
        }
    }

    // Zadanie 3
    static void OperacjeNaTablicy()
    {
        double[] liczby = new double[10];
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Podaj liczbę nr {i + 1}:");
            liczby[i] = double.Parse(Console.ReadLine());
        }

        int wybor;
        do
        {
            Console.WriteLine("1-Od początku, 2-Od końca, 3-Nieparzyste indeksy, 4-Parzyste indeksy, 0-Wyjście");
            wybor = int.Parse(Console.ReadLine());

            if (wybor == 1) WyswietlOdPoczatku(liczby);
            else if (wybor == 2) WyswietlOdKonca(liczby);
            else if (wybor == 3) WyswietlNieparzysteIndeksy(liczby);
            else if (wybor == 4) WyswietlParzysteIndeksy(liczby);
        } while (wybor != 0);
    }

    static void WyswietlOdPoczatku(double[] tablica)
    {
        Console.WriteLine("Tablica od początku:");
        foreach (var liczba in tablica)
        {
            Console.WriteLine(liczba);
        }
    }

    static void WyswietlOdKonca(double[] tablica)
    {
        Console.WriteLine("Tablica od końca:");
        for (int i = tablica.Length - 1; i >= 0; i--)
        {
            Console.WriteLine(tablica[i]);
        }
    }

    static void WyswietlNieparzysteIndeksy(double[] tablica)
    {
        Console.WriteLine("Elementy o nieparzystych indeksach:");
        for (int i = 1; i < tablica.Length; i += 2)
        {
            Console.WriteLine(tablica[i]);
        }
    }

    static void WyswietlParzysteIndeksy(double[] tablica)
    {
        Console.WriteLine("Elementy o parzystych indeksach:");
        for (int i = 0; i < tablica.Length; i += 2)
        {
            Console.WriteLine(tablica[i]);
        }
    }

    // Zadanie 4
    static void OperacjeNaElementachTablicy()
    {
        double[] liczby = new double[10];
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Podaj liczbę nr {i + 1}:");
            liczby[i] = double.Parse(Console.ReadLine());
        }

        double suma = 0, iloczyn = 1, min = liczby[0], max = liczby[0];
        foreach (var liczba in liczby)
        {
            suma += liczba;
            iloczyn *= liczba;
            if (liczba < min) min = liczba;
            if (liczba > max) max = liczba;
        }
        Console.WriteLine($"Suma: {suma}");
        Console.WriteLine($"Iloczyn: {iloczyn}");
        Console.WriteLine($"Średnia: {suma / liczby.Length}");
        Console.WriteLine($"Minimalna: {min}");
        Console.WriteLine($"Maksymalna: {max}");
    }

    // Zadanie 5
    static void WyswietlLiczbyZWyjatkami()
    {
        for (int i = 20; i >= 0; i--)
        {
            if (i == 2 || i == 6 || i == 9 || i == 15 || i == 19) continue;
            Console.WriteLine(i);
        }
    }

    // Zadanie 6
    static void PetlaNieskonczona()
    {
        do
        {
            Console.WriteLine("Podaj liczbę:");
            int liczba = int.Parse(Console.ReadLine());
            if (liczba < 0) break;
        } while (true);
    }

    // Zadanie 7
    static void SortowanieLiczb()
    {
        Console.WriteLine("Podaj ilość liczb:");
        int n = int.Parse(Console.ReadLine());
        int[] liczby = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Podaj liczbę nr {i + 1}:");
            liczby[i] = int.Parse(Console.ReadLine());
        }

        // Sortowanie bąbelkowe
        for (int i = 0; i < liczby.Length - 1; i++)
        {
            for (int j = 0; j < liczby.Length - i - 1; j++)
            {
                if (liczby[j] > liczby[j + 1])
                {
                    int temp = liczby[j];
                    liczby[j] = liczby[j + 1];
                    liczby[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("Posortowane liczby:");
        foreach (var liczba in liczby)
        {
            Console.WriteLine(liczba);
        }
    }
}
