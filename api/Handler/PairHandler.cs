using Bigproject.Models;
using Bigproject.DataAccess;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Bigproject.Handler
{
    public class CarPairHandler
    {
        public static List<CarPair> allCarPairs = new List<CarPair>();

        public CarPairHandler()
        {

        }

        public List<CarPair> GetAllCarPairs()
        {
            List<CarPair> pairs = new List<CarPair>();

            ConnectionString myConnection = new ConnectionString(); 
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM car_pairs";

            using var cmd = new MySqlCommand(stm, con);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CarPair pair = new CarPair
                {
                    PairId = reader.GetString("pairID"),
                    UserId = reader.GetString("userID"),
                    GasCarId = reader.GetString("gasCarId"),
                    ElectricCarId = reader.GetString("electricCarId"),
                };
                pairs.Add(pair);
            }

            return pairs;
        }

        public void AddCarPair(CarPair newCarPair)
        {
            SaveCarPair saveCarPair = new SaveCarPair();
            saveCarPair.SavePair(newCarPair);
            allCarPairs.Add(newCarPair);
        }

        public void EditCarPair(string id, CarPair editCarPair)
        {
            int index = allCarPairs.FindIndex(s => s.PairId == id);
            allCarPairs.RemoveAt(index);

            SaveCarPair saveCarPair = new SaveCarPair();
            saveCarPair.UpdateCarPair(editCarPair);
            allCarPairs.Add(editCarPair);
        }

        public void DeleteCarPair(string id)
        {
            int index = allCarPairs.FindIndex(s => s.PairId == id);
            allCarPairs.RemoveAt(index);

            DeleteCarPair deleteCarPair = new DeleteCarPair();
            deleteCarPair.DeleteCarPairByID(id);
        }
    }
}