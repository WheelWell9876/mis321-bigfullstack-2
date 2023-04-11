using Bigproject.Interfaces;
using Bigproject.Models;
using MySql.Data.MySqlClient;

namespace Bigproject.DataAccess
{
    public class SaveCarPair : ISaveCarPair
    {
        public static void CreateCarPairTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE car_pairs(pairId VARCHAR(255) PRIMARY KEY, gasCarId VARCHAR(255), electricCarId VARCHAR(255), userId VARCHAR(255), FOREIGN KEY(gasCarId) REFERENCES gas_cars(gasCarId), FOREIGN KEY(electricCarId) REFERENCES electric_cars(electricCarId), FOREIGN KEY(userId) REFERENCES users(userId))";

            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }

        public void CreatePair(CarPair myPair)
        {
            throw new NotImplementedException();
        }

        public void SavePair(CarPair myPair)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO car_pairs(pairId, gasCarId, electricCarId, userId) VALUES(@pairId, @gasCarId, @electricCarId, @userId)";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@pairId", myPair.PairId);
            cmd.Parameters.AddWithValue("@gasCarId", myPair.GasCarId);
            cmd.Parameters.AddWithValue("@electricCarId", myPair.ElectricCarId);
            cmd.Parameters.AddWithValue("@userId", myPair.UserId);

            cmd.ExecuteNonQuery();
        }

        public void UpdateCarPair(CarPair myPair)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE car_pairs SET gasCarId = @gasCarId, electricCarId = @electricCarId, userId = @userId,  WHERE pairId = @pairId";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@pairId", myPair.PairId);
            cmd.Parameters.AddWithValue("@gasCarId", myPair.GasCarId);
            cmd.Parameters.AddWithValue("@electricCarId", myPair.ElectricCarId);
            cmd.Parameters.AddWithValue("@userId", myPair.UserId);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        public void InitializeDatabase()
        {
            string sql = @"USE p6nr5re8fmcvgnki;

                CREATE TABLE IF NOT EXISTS car_pairs (
                    pairId VARCHAR(255) PRIMARY KEY,
                    gasCarId VARCHAR(255),
                    electricCarId VARCHAR(255),
                    userId VARCHAR(255)
                );

                SELECT * FROM p6nr5re8fmcvgnki.car_pairs;";

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            using var cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public CarPair GetPairById(string id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM car_pairs WHERE pairId = @pairId";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@pairId", id);
            cmd.Prepare();

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                CarPair pair = new CarPair
                {
                    UserId = reader.GetString("pairId"),
                };
                return pair;
            }
            else
            {
                return null;
            }
        }
    }
}