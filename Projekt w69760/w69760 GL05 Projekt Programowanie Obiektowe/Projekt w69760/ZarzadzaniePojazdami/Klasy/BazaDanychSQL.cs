using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Projekt.ZarzadzaniePojazdami.Interfejsy;

namespace Projekt.ZarzadzaniePojazdami.Klasy
{
    public class BazaDanychSQL : BazaDanychBase
    {
        private readonly string _connectionString;

        public BazaDanychSQL(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Connection string nie moze byc pusty");
            _connectionString = connectionString;
        }

        public override void DodajPojazd(IPojazd pojazd)
        {
            if (pojazd == null)
            {
                Console.WriteLine("Niepoprawny pojazd.");
                return;
            }
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Wstawienie pojazdu do glownej tabeli Pojazdy
                    string queryMain = "INSERT INTO Pojazdy (ID, Typ, Marka, Model, RokProdukcji, NumerRejestracyjny, DataDodania) " +
                                       "VALUES (@ID, @Typ, @Marka, @Model, @RokProdukcji, @NumerRejestracyjny, @DataDodania)";
                    using (var commandMain = new SqlCommand(queryMain, connection))
                    {
                        commandMain.Parameters.AddWithValue("@ID", pojazd.Id);
                        commandMain.Parameters.AddWithValue("@Typ", pojazd.Typ);
                        commandMain.Parameters.AddWithValue("@Marka", pojazd.Marka);
                        commandMain.Parameters.AddWithValue("@Model", pojazd.Model);
                        commandMain.Parameters.AddWithValue("@RokProdukcji", pojazd.RokProdukcji);
                        commandMain.Parameters.AddWithValue("@NumerRejestracyjny", pojazd.NumerRejestracyjny);
                        commandMain.Parameters.AddWithValue("@DataDodania", pojazd.DataDodania);
                        commandMain.ExecuteNonQuery();
                    }

                    // W zaleznosci od typu, wstawiamy dane szczegolowe do odpowiedniej tabeli
                    if (pojazd.Typ == "Autobus")
                    {
                        Autobus a = (Autobus)pojazd;
                        string queryDetail = "INSERT INTO Autobusy (ID, LiczbaMiejsc, Dlugosc) " +
                                             "VALUES (@ID, @LiczbaMiejsc, @Dlugosc)";
                        using (var commandDetail = new SqlCommand(queryDetail, connection))
                        {
                            commandDetail.Parameters.AddWithValue("@ID", a.Id);
                            commandDetail.Parameters.AddWithValue("@LiczbaMiejsc", a.LiczbaMiejsc);
                            commandDetail.Parameters.AddWithValue("@Dlugosc", a.Dlugosc);
                            commandDetail.ExecuteNonQuery();
                        }
                    }
                    else if (pojazd.Typ == "Ciezarowka")
                    {
                        Ciezarowka c = (Ciezarowka)pojazd;
                        string queryDetail = "INSERT INTO Ciezarowki (ID, Ladownosc, Dlugosc) " +
                                             "VALUES (@ID, @Ladownosc, @Dlugosc)";
                        using (var commandDetail = new SqlCommand(queryDetail, connection))
                        {
                            commandDetail.Parameters.AddWithValue("@ID", c.Id);
                            commandDetail.Parameters.AddWithValue("@Ladownosc", c.Ladownosc);
                            commandDetail.Parameters.AddWithValue("@Dlugosc", c.Dlugosc);
                            commandDetail.ExecuteNonQuery();
                        }
                    }
                    else if (pojazd.Typ == "Dostawczak")
                    {
                        Dostawczak d = (Dostawczak)pojazd;
                        string queryDetail = "INSERT INTO Dostawczaki (ID, Ladownosc) " +
                                             "VALUES (@ID, @Ladownosc)";
                        using (var commandDetail = new SqlCommand(queryDetail, connection))
                        {
                            commandDetail.Parameters.AddWithValue("@ID", d.Id);
                            commandDetail.Parameters.AddWithValue("@Ladownosc", d.Ladownosc);
                            commandDetail.ExecuteNonQuery();
                        }
                    }
                    else if (pojazd.Typ == "Motocykl")
                    {
                        Motocykl m = (Motocykl)pojazd;
                        string queryDetail = "INSERT INTO Motocykle (ID, PojemnoscSilnika) " +
                                             "VALUES (@ID, @PojemnoscSilnika)";
                        using (var commandDetail = new SqlCommand(queryDetail, connection))
                        {
                            commandDetail.Parameters.AddWithValue("@ID", m.Id);
                            commandDetail.Parameters.AddWithValue("@PojemnoscSilnika", m.PojemnoscSilnika);
                            commandDetail.ExecuteNonQuery();
                        }
                    }
                    else if (pojazd.Typ == "SamochodOsobowy")
                    {
                        SamochodOsobowy so = (SamochodOsobowy)pojazd;
                        string queryDetail = "INSERT INTO SamochodyOsobowe (ID, LiczbaMiejsc) " +
                                             "VALUES (@ID, @LiczbaMiejsc)";
                        using (var commandDetail = new SqlCommand(queryDetail, connection))
                        {
                            commandDetail.Parameters.AddWithValue("@ID", so.Id);
                            commandDetail.Parameters.AddWithValue("@LiczbaMiejsc", so.LiczbaMiejsc);
                            commandDetail.ExecuteNonQuery();
                        }
                    }
                    else if (pojazd.Typ == "SamochodElektryczny")
                    {
                        SamochodElektryczny se = (SamochodElektryczny)pojazd;
                        string queryDetail = "INSERT INTO SamochodyElektryczne (ID, LiczbaMiejsc, PojemnoscBaterii, Zasieg) " +
                                             "VALUES (@ID, @LiczbaMiejsc, @PojemnoscBaterii, @Zasieg)";
                        using (var commandDetail = new SqlCommand(queryDetail, connection))
                        {
                            commandDetail.Parameters.AddWithValue("@ID", se.Id);
                            commandDetail.Parameters.AddWithValue("@LiczbaMiejsc", se.LiczbaMiejsc);
                            commandDetail.Parameters.AddWithValue("@PojemnoscBaterii", se.PojemnoscBaterii);
                            commandDetail.Parameters.AddWithValue("@Zasieg", se.Zasieg);
                            commandDetail.ExecuteNonQuery();
                        }
                    }

                    Console.WriteLine("Pojazd dodany do bazy SQL wraz ze szczegolowymi danymi.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad SQL: " + ex.Message);
            }
        }

        public override void UsunPojazd(string rejestracja)
        {
            if (string.IsNullOrWhiteSpace(rejestracja))
            {
                Console.WriteLine("Niepoprawna rejestracja.");
                return;
            }
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("DELETE FROM Pojazdy WHERE NumerRejestracyjny = @Rejestracja", connection);
                    command.Parameters.AddWithValue("@Rejestracja", rejestracja);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad podczas usuwania pojazdu z SQL: " + ex.Message);
            }
        }

        public override void EdytujRejestracje(string staraRejestracja, string nowaRejestracja)
        {
            if (string.IsNullOrWhiteSpace(staraRejestracja) || string.IsNullOrWhiteSpace(nowaRejestracja))
            {
                Console.WriteLine("Niepoprawne dane rejestracyjne.");
                return;
            }
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("UPDATE Pojazdy SET NumerRejestracyjny = @Nowa WHERE NumerRejestracyjny = @Stara", connection);
                    command.Parameters.AddWithValue("@Stara", staraRejestracja);
                    command.Parameters.AddWithValue("@Nowa", nowaRejestracja);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad podczas edycji rejestracji w SQL: " + ex.Message);
            }
        }

        public override IPojazd? WyszukajPojazd(string rejestracja)
        {
            if (string.IsNullOrWhiteSpace(rejestracja))
            {
                Console.WriteLine("Niepoprawna rejestracja.");
                return null;
            }
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT ID, Typ, Marka, Model, RokProdukcji, NumerRejestracyjny, DataDodania " +
                                   "FROM Pojazdy WHERE NumerRejestracyjny = @Rejestracja";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Rejestracja", rejestracja);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return ZamienDaneNaPojazd(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad podczas wyszukiwania pojazdu w SQL: " + ex.Message);
            }
            return null;
        }

        public override List<IPojazd> WyswietlWszystkie()
        {
            var pojazdy = new List<IPojazd>();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT ID, Typ, Marka, Model, RokProdukcji, NumerRejestracyjny, DataDodania FROM Pojazdy";

                    using (var command = new SqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var pojazd = ZamienDaneNaPojazd(reader);
                            if (pojazd != null)
                                pojazdy.Add(pojazd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad podczas wczytywania pojazdow z SQL: " + ex.Message);
            }
            return pojazdy;
        }

        public override List<IPojazd> WyswietlWedlugTypu(string typ)
        {
            if (string.IsNullOrWhiteSpace(typ))
            {
                Console.WriteLine("Niepoprawny typ.");
                return new List<IPojazd>();
            }
            var pojazdy = new List<IPojazd>();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT ID, Typ, Marka, Model, RokProdukcji, NumerRejestracyjny, DataDodania " +
                                   "FROM Pojazdy WHERE Typ = @Typ";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Typ", typ);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var pojazd = ZamienDaneNaPojazd(reader);
                                if (pojazd != null)
                                    pojazdy.Add(pojazd);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad podczas wczytywania pojazdow wedlug typu z SQL: " + ex.Message);
            }
            return pojazdy;
        }

        public override void PokazStatystyki()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT Typ, COUNT(*) FROM Pojazdy GROUP BY Typ", connection);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(0) + ": " + reader.GetInt32(1) + " pojazdow");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad podczas wyswietlania statystyk w SQL: " + ex.Message);
            }
        }

        private IPojazd? ZamienDaneNaPojazd(SqlDataReader reader)
        {
            try
            {
                int id = reader.GetInt32(0);
                string typ = reader.GetString(1);
                string marka = reader.GetString(2);
                string model = reader.GetString(3);
                int rok = reader.GetInt32(4);
                string rejestracja = reader.GetString(5);
                DateTime dataDodania = reader.GetDateTime(6);

                if (typ == "Autobus")
                    return new Autobus(id, marka, model, rok, rejestracja, dataDodania, 50, 12.0);
                if (typ == "Ciezarowka")
                    return new Ciezarowka(id, marka, model, rok, rejestracja, dataDodania, 10.0, 8.0);
                if (typ == "Dostawczak")
                    return new Dostawczak(id, marka, model, rok, rejestracja, dataDodania, 3.5);
                if (typ == "Motocykl")
                    return new Motocykl(id, marka, model, rok, rejestracja, dataDodania, 600);
                if (typ == "SamochodOsobowy")
                    return new SamochodOsobowy(id, marka, model, rok, rejestracja, dataDodania, 5);
                if (typ == "SamochodElektryczny")
                    return new SamochodElektryczny(id, marka, model, rok, rejestracja, dataDodania, 5, 60.0, 400);

                throw new Exception("Nieznany typ pojazdu: " + typ);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Blad parsowania danych: " + ex.Message);
                return null;
            }
        }
    }
}