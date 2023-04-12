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

            string stm = @"CREATE TABLE gasCars(gasCarID VARCHAR(255) PRIMARY KEY, gasCarMake TEXT, gasCarModel TEXT, gasCarYear INTEGER, gasCarRange INTEGER, gasCarPrice DOUBLE, gasCarMpg DOUBLE, gasCarAddOn TEXT)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        public void CreateGasCar(Gas_Car myGasCar)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO gasCars(gasCarID, gasCarMake, gasCarModel, gasCarYear, gasCarRange, gasCarPrice, gasCarMpg, gasCarAddOn) VALUES(@gasCarID, @gasCarMake, @gasCarModel, @gasCarYear, @gasCarRange, @gasCarPrice, @gasCarMpg, @gasCarAddOn)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@gasCarID", myGasCar.GasCarId);
            cmd.Parameters.AddWithValue("@gasCarMake", myGasCar.Make);
            cmd.Parameters.AddWithValue("@gasCarModel", myGasCar.Model);
            cmd.Parameters.AddWithValue("@gasCarYear", myGasCar.Year);
            cmd.Parameters.AddWithValue("@gasCarRange", myGasCar.Range);
            cmd.Parameters.AddWithValue("@gasCarPrice", myGasCar.Price);
            cmd.Parameters.AddWithValue("@gasCarMpg", myGasCar.MPG);
            cmd.Parameters.AddWithValue("@gasCarAddOn", myGasCar.AddOn);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        public void UpdateGasCar(Gas_Car myGasCar)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE gasCars SET gasCarMake = @gasCarMake, gasCarModel = @gasCarModel, gasCarYear = @gasCarYear, gasCarRange = @gasCarRange, gasCarPrice = @gasCarPrice, gasCarMpg = @gasCarMpg, gasCarAddOn = @gasCarAddOn WHERE gasCarID = @gasCarID";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@gasCarID", myGasCar.GasCarId);
            cmd.Parameters.AddWithValue("@gasCarMake", myGasCar.Make);
            cmd.Parameters.AddWithValue("@gasCarModel", myGasCar.Model);
            cmd.Parameters.AddWithValue("@gasCarYear", myGasCar.Year);
            cmd.Parameters.AddWithValue("@gasCarRange", myGasCar.Range);
            cmd.Parameters.AddWithValue("@gasCarPrice", myGasCar.Price);
            cmd.Parameters.AddWithValue("@gasCarMpg", myGasCar.MPG);
            cmd.Parameters.AddWithValue("@gasCarAddOn", myGasCar.AddOn);

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
                @"USE p6nr5re8fmcvgnki;
                DROP TABLE IF EXISTS gasCars;
                CREATE TABLE IF NOT EXISTS gasCars (
                    gasCarID VARCHAR(255) PRIMARY KEY,
                    gasCarMake TEXT NOT NULL,
                    gasCarModel TEXT NOT NULL,
                    gasCarYear INTEGER NOT NULL,
                    gasCarRange INTEGER NOT NULL DEFAULT 0,
                    gasCarPrice DOUBLE NOT NULL DEFAULT 0,
                    gasCarMpg DOUBLE NOT NULL DEFAULT 0,
                    gasCarAddOn TEXT NOT NULL
                );
                SELECT * FROM p6nr5re8fmcvgnki.gasCars;";

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            using var cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public Gas_Car GetGasCarById(string id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM gasCars WHERE gasCarID = @gasCarID";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@gasCarID", id);
            cmd.Prepare();

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Gas_Car gasCar = new Gas_Car
                {
                    GasCarId = reader.GetString("gasCarID"),
                    Make = reader.GetString("gasCarMake"),
                    Model = reader.GetString("gasCarModel"),
                    Year = reader.GetInt32("gasCarYear"),
                    Range = reader.GetInt32("gasCarRange"),
                    Price = reader.GetDouble("gasCarPrice"),
                    MPG = reader.GetDouble("gasCarMpg"),
                    AddOn = reader.GetString("gasCarAddOn"),
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