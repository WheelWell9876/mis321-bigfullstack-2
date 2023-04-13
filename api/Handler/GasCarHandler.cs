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
            // List<Gas_Car> allGasCars = new List<Gas_Car>();
            allGasCars.Clear();

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
            System.Console.WriteLine("ID parameter: " + id);
            int index = allGasCars.FindIndex(s => s.GasCarId == id);
            System.Console.WriteLine("PAST INDEX");

            System.Console.WriteLine("Index: " + index);
            System.Console.WriteLine("All gas cars:");
            foreach (Gas_Car gasCar in allGasCars)
            {
                System.Console.WriteLine($"ID: {gasCar.GasCarId}, Make: {gasCar.Make}, Model: {gasCar.Model}");
            }

            if (index >= 0 && index < allGasCars.Count)
            {
                allGasCars.RemoveAt(index);

                SaveGasCar saveGasCar = new SaveGasCar();
                saveGasCar.UpdateGasCar(editGasCar);
                allGasCars.Add(editGasCar);
            }
            else
            {
                System.Console.WriteLine("System error in IF statement");
            }
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