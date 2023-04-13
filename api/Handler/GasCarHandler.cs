using Bigproject.Models;
using Bigproject.DataAccess;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Bigproject.DataAccess
{
    public class GasCarHandler
    {
        public static List<Gas_Car> allGasCars = new List<Gas_Car>();

        public GasCarHandler()
        {
            
        }

        public List<Gas_Car> GetAllGasCars()
        {
            List<Gas_Car> allGasCars = new List<Gas_Car>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM gasCars";

            using var cmd = new MySqlCommand(stm, con);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
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

                allGasCars.Add(gasCar);
            }

            return allGasCars;
        }

        public void AddGasCar(Gas_Car newGasCar)
        {
            SaveGasCar saveGasCar = new SaveGasCar();
            saveGasCar.CreateGasCar(newGasCar);
            allGasCars.Add(newGasCar);
        }

        public void EditGasCar(string id, Gas_Car editGasCar)
        {
            int index = allGasCars.FindIndex(s => s.GasCarId == id);
            allGasCars.RemoveAt(index);

            SaveGasCar saveGasCar = new SaveGasCar();
            saveGasCar.UpdateGasCar(editGasCar);
            allGasCars.Add(editGasCar);
        }

        public void DeleteGasCar(string id)
        {
            int index = allGasCars.FindIndex(s => s.GasCarId == id);
            allGasCars.RemoveAt(index);

            DeleteGasCar deleteGasCar = new DeleteGasCar();
            deleteGasCar.DeleteGasCarByID(id);
        }
    }
}