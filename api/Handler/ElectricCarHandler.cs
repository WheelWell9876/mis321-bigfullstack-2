using Bigproject.Models;
using Bigproject.DataAccess;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Bigproject.Handler
{
    public class ElectricCarHandler
    {
        public static List<Electric_Car> allElectricCars = new List<Electric_Car>();

        public ElectricCarHandler()
        {

        }

        public List<Electric_Car> GetAllElectricCars()
        {
            List<Electric_Car> electricCars = new List<Electric_Car>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM electricCars";

            using var cmd = new MySqlCommand(stm, con);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
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
                electricCars.Add(electricCar);
            }

            return electricCars;
        }

        public void AddElectricCar(Electric_Car newElectricCar)
        {
            SaveElectricCar saveElectricCar = new SaveElectricCar();
            saveElectricCar.CreateElectricCar(newElectricCar);
            allElectricCars.Add(newElectricCar);
        }

        public void EditElectricCar(string id, Electric_Car editElectricCar)
        {
            int index = allElectricCars.FindIndex(s => s.ElectricCarId == id);
            allElectricCars.RemoveAt(index);

            SaveElectricCar saveElectricCar = new SaveElectricCar();
            saveElectricCar.UpdateElectricCar(editElectricCar);
            allElectricCars.Add(editElectricCar);
        }

        public void DeleteElectricCar(string id)
        {
            int index = allElectricCars.FindIndex(s => s.ElectricCarId == id);
            allElectricCars.RemoveAt(index);

            DeleteElectricCar deleteElectricCar = new DeleteElectricCar();
            deleteElectricCar.DeleteElectricCarByID(id);
        }
    }
}
