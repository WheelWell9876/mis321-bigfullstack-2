using Bigproject.Interfaces;
using Bigproject.Models;
using MySql.Data.MySqlClient;
using System;

namespace Bigproject.DataAccess
{
    public class SaveGasCar : ISaveGasCar
    {
        public static void CreateGasCarTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE gasCars(gasCarId VARCHAR(255) PRIMARY KEY, make TEXT, model TEXT, year INTEGER, range INTEGER, price DOUBLE, mpg DOUBLE, addOn TEXT)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        public void CreateGasCar(Gas_Car myGasCar)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO gasCars(gasCarId, make, model, year, range, price, mpg, addOn) VALUES(@gasCarId, @make, @model, @year, @range, @price, @mpg, @addOn)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@gasCarId", myGasCar.GasCarId);
            cmd.Parameters.AddWithValue("@make", myGasCar.Make);
            cmd.Parameters.AddWithValue("@model", myGasCar.Model);
            cmd.Parameters.AddWithValue("@year", myGasCar.Year);
            cmd.Parameters.AddWithValue("@range", myGasCar.Range);
            cmd.Parameters.AddWithValue("@price", myGasCar.Price);
            cmd.Parameters.AddWithValue("@mpg", myGasCar.MPG);
            cmd.Parameters.AddWithValue("@addOn", myGasCar.AddOn);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        public void UpdateGasCar(Gas_Car myGasCar)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE gasCars SET make = @make, model = @model, year = @year, range = @range, price = @price, mpg = @mpg, addOn = @addOn WHERE gasCarId = @gasCarId";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@gasCarId", myGasCar.GasCarId);
            cmd.Parameters.AddWithValue("@make", myGasCar.Make);
            cmd.Parameters.AddWithValue("@model", myGasCar.Model);
            cmd.Parameters.AddWithValue("@year", myGasCar.Year);
            cmd.Parameters.AddWithValue("@range", myGasCar.Range);
            cmd.Parameters.AddWithValue("@price", myGasCar.Price);
            cmd.Parameters.AddWithValue("@mpg", myGasCar.MPG);
            cmd.Parameters.AddWithValue("@addOn", myGasCar.AddOn);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        void ISaveGasCar.SaveGasCar(Gas_Car myGasCar)
        {
            CreateGasCar(myGasCar);
        }

        public void InitializeDatabase()
        {
            string sql = 
                @"USE v7z0pdstr5cezoil;
                DROP TABLE IF EXISTS gasCars;
                CREATE TABLE IF NOT EXISTS gasCars (
                    gasCarId VARCHAR(255) PRIMARY KEY,
                    make TEXT NOT NULL,
                    model TEXT NOT NULL,
                    year INTEGER NOT NULL,
                    range INTEGER NOT NULL DEFAULT 0,
                    price DOUBLE NOT NULL DEFAULT 0,
                    mpg DOUBLE NOT NULL DEFAULT 0,
                    addOn TEXT NOT NULL
                );
                SELECT * FROM v7z0pdstr5cezoil.gasCars;";

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            using var cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public Gas_Car GetGasById(string id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM gasCars WHERE gasCarId = @gasCarId";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@gasCarId", id);
            cmd.Prepare();

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Gas_Car gasCar = new Gas_Car
                {
                    GasCarId = reader.GetString("gasCarId"),
                    Make = reader.GetString("make"),
                    Model = reader.GetString("model"),
                    Year = reader.GetInt32("year"),
                    Range = reader.GetInt32("range"),
                    Price = reader.GetDouble("price"),
                    MPG = reader.GetDouble("mpg"),
                    AddOn = reader.GetString("addOn"),
                };
                return gasCar;
            }
            else
            {
                return null;
            }
        }
    }
}