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

            string stm = @"CREATE TABLE car_pairs(pairID VARCHAR(255) PRIMARY KEY, gasCarID VARCHAR(255), electricCarID VARCHAR(255), userID VARCHAR(255), FOREIGN KEY(gasCarID) REFERENCES gas_cars(gasCarID), FOREIGN KEY(electricCarID) REFERENCES electric_cars(electricCarID), FOREIGN KEY(userID) REFERENCES users(userID))";

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

            string stm = @"INSERT INTO car_pairs(pairID, gasCarID, electricCarID, userID) VALUES(@pairID, @gasCarID, @electricCarID, @userID)";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@pairID", myPair.PairId);
            cmd.Parameters.AddWithValue("@gasCarID", myPair.GasCarId);
            cmd.Parameters.AddWithValue("@electricCarID", myPair.ElectricCarId);
            cmd.Parameters.AddWithValue("@userID", myPair.UserId);

            cmd.ExecuteNonQuery();
        }

        public void UpdateCarPair(CarPair myPair)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE car_pairs SET gasCarID = @gasCarID, electricCarID = @electricCarID, userID = @userID,  WHERE pairID = @pairID";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@pairID", myPair.PairId);
            cmd.Parameters.AddWithValue("@gasCarID", myPair.GasCarId);
            cmd.Parameters.AddWithValue("@electricCarID", myPair.ElectricCarId);
            cmd.Parameters.AddWithValue("@userID", myPair.UserId);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        public void InitializeDatabase()
        {
            string sql = @"USE p6nr5re8fmcvgnki;

                CREATE TABLE IF NOT EXISTS car_pairs (
                    pairID VARCHAR(255) PRIMARY KEY,
                    gasCarID VARCHAR(255),
                    electricCarID VARCHAR(255),
                    userID VARCHAR(255)
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

            string stm = "SELECT * FROM car_pairs WHERE pairID = @pairID";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@pairID", id);
            cmd.Prepare();

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                CarPair pair = new CarPair
                {
                    UserId = reader.GetString("pairID"),
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