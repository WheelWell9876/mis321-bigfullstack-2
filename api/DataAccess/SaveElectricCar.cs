using Bigproject.Interfaces;
using Bigproject.Models;
using MySql.Data.MySqlClient;
using System;

namespace Bigproject.DataAccess
{
    public class SaveElectricCar : ISaveElectricCar
    {
        public static void CreateElectricCarTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE electricCars(electricCarId VARCHAR(255) PRIMARY KEY, make TEXT, model TEXT, year INTEGER, range INTEGER, price DOUBLE, kwh DOUBLE, addOn TEXT)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        public void CreateElectricCar(Electric_Car myElectricCar)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO electricCars(electricCarId, make, model, year, range, price, kwh, addOn) VALUES(@electricCarId, @make, @model, @year, @range, @price, @kwh, @addOn)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@electricCarId", myElectricCar.ElectricCarId);
            cmd.Parameters.AddWithValue("@make", myElectricCar.Make);
            cmd.Parameters.AddWithValue("@model", myElectricCar.Model);
            cmd.Parameters.AddWithValue("@year", myElectricCar.Year);
            cmd.Parameters.AddWithValue("@range", myElectricCar.Range);
            cmd.Parameters.AddWithValue("@price", myElectricCar.Price);
            cmd.Parameters.AddWithValue("@kwh", myElectricCar.KWH);
            cmd.Parameters.AddWithValue("@addOn", myElectricCar.AddOn);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        public void UpdateElectricCar(Electric_Car myElectricCar)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE electricCars SET make = @make, model = @model, year = @year, range = @range, price = @price, kwh = @kwh, addOn = @addOn WHERE electricCarId = @electricCarId";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@electricCarId", myElectricCar.ElectricCarId);
            cmd.Parameters.AddWithValue("@make", myElectricCar.Make);
            cmd.Parameters.AddWithValue("@model", myElectricCar.Model);
            cmd.Parameters.AddWithValue("@year", myElectricCar.Year);
            cmd.Parameters.AddWithValue("@range", myElectricCar.Range);
            cmd.Parameters.AddWithValue("@price", myElectricCar.Price);
            cmd.Parameters.AddWithValue("@kwh", myElectricCar.KWH);
            cmd.Parameters.AddWithValue("@addOn", myElectricCar.AddOn);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        void ISaveElectricCar.SaveElectricCar(Electric_Car myElectricCar)
        {
            CreateElectricCar(myElectricCar);
        }

        public void InitializeDatabase()
        {
            string sql = 
                @"USE v7z0pdstr5cezoil;
                DROP TABLE IF EXISTS electricCars;
                CREATE TABLE IF NOT EXISTS electricCars (
                    electricCarId VARCHAR(255) PRIMARY KEY,
                    make TEXT NOT NULL,
                    model TEXT NOT NULL,
                    year INTEGER NOT NULL,
                    range INTEGER NOT NULL DEFAULT 0,
                    price DOUBLE NOT NULL DEFAULT 0,
                    kwh DOUBLE NOT NULL DEFAULT 0,
                    addOn TEXT NOT NULL
                );
                SELECT * FROM v7z0pdstr5cezoil.electricCars;";

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            using var cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public Electric_Car GetElectricById(string id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM electricCars WHERE electricCarId = @electricCarId";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@electricCarId", id);
            cmd.Prepare();

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Electric_Car electricCar = new Electric_Car
                {
                    ElectricCarId = reader.GetString("electricCarId"),
                    Make = reader.GetString("make"),
                    Model = reader.GetString("model"),
                    Year = reader.GetInt32("year"),
                    Range = reader.GetInt32("range"),
                    Price = reader.GetDouble("price"),
                    KWH = reader.GetDouble("kwh"),
                    AddOn = reader.GetString("addOn"),
                };
                return electricCar;
            }
            else
            {
                return null;
            }
        }
    }
}