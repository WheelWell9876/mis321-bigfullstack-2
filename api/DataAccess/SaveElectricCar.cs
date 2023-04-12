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

            string stm = @"CREATE TABLE electricCars(electricCarID VARCHAR(255) PRIMARY KEY, electricCarMake TEXT, electricCarModel TEXT, electricCarYear INTEGER, electricCarRange INTEGER, electricCarPrice DOUBLE, electricCarKwh DOUBLE, electricCarAddOn TEXT)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        public void CreateElectricCar(Electric_Car myElectricCar)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO electricCars(electricCarID, electricCarMake, electricCarModel, electricCarYear, electricCarRange, electricCarPrice, electricCarKwh, electricCarAddOn) VALUES(@electricCarID, @electricCarMake, @electricCarModel, @electricCarYear, @electricCarRange, @electricCarPrice, @electricCarKwh, @electricCarAddOn)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@electricCarID", myElectricCar.ElectricCarId);
            cmd.Parameters.AddWithValue("@electricCarMake", myElectricCar.Make);
            cmd.Parameters.AddWithValue("@electricCarModel", myElectricCar.Model);
            cmd.Parameters.AddWithValue("@electricCarYear", myElectricCar.Year);
            cmd.Parameters.AddWithValue("@electricCarRange", myElectricCar.Range);
            cmd.Parameters.AddWithValue("@electricCarPrice", myElectricCar.Price);
            cmd.Parameters.AddWithValue("@electricCarKwh", myElectricCar.KWH);
            cmd.Parameters.AddWithValue("@electricCarAddOn", myElectricCar.AddOn);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        public void UpdateElectricCar(Electric_Car myElectricCar)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE electricCars SET electricCarMake = @electricCarMake, electricCarModel = @electricCarModel, electricCarYear = @electricCarYear, electricCarRange = @electricCarRange, electricCarPrice = @electricCarPrice, electricCarKwh = @electricCarKwh, electricCarAddOn = @electricCarAddOn WHERE electricCarID = @electricCarID";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@electricCarID", myElectricCar.ElectricCarId);
            cmd.Parameters.AddWithValue("@electricCarMake", myElectricCar.Make);
            cmd.Parameters.AddWithValue("@electricCarModel", myElectricCar.Model);
            cmd.Parameters.AddWithValue("@electricCarYear", myElectricCar.Year);
            cmd.Parameters.AddWithValue("@electricCarRange", myElectricCar.Range);
            cmd.Parameters.AddWithValue("@electricCarPrice", myElectricCar.Price);
            cmd.Parameters.AddWithValue("@electricCarKwh", myElectricCar.KWH);
            cmd.Parameters.AddWithValue("@electricCarAddOn", myElectricCar.AddOn);

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
                @"USE p6nr5re8fmcvgnki;
                DROP TABLE IF EXISTS electricCars;
                CREATE TABLE IF NOT EXISTS electricCars (
                    electricCarID VARCHAR(255) PRIMARY KEY,
                    electricCarMake TEXT NOT NULL,
                    electricCarModel TEXT NOT NULL,
                    electricCarYear INTEGER NOT NULL,
                    electricCarRange INTEGER NOT NULL DEFAULT 0,
                    electricCarPrice DOUBLE NOT NULL DEFAULT 0,
                    electricCarKwh DOUBLE NOT NULL DEFAULT 0,
                    electricCarAddOn TEXT NOT NULL
                );
                SELECT * FROM p6nr5re8fmcvgnki.electricCars;";

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            using var cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public Electric_Car GetElectricCarById(string id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM electricCars WHERE electricCarID = @electricCarID";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@electricCarID", id);
            cmd.Prepare();

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Electric_Car electricCar = new Electric_Car
                {
                    ElectricCarId = reader.GetString("electricCarID"),
                    Make = reader.GetString("electricCarMake"),
                    Model = reader.GetString("electricCarModel"),
                    Year = reader.GetInt32("electricCarYear"),
                    Range = reader.GetInt32("electricCarRange"),
                    Price = reader.GetDouble("electricCarPrice"),
                    KWH = reader.GetDouble("electricCarKwh"),
                    AddOn = reader.GetString("electricCarAddOn"),
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