using Bigproject.Interfaces;
using Bigproject.Models;
using MySql.Data.MySqlClient;
using System;

namespace Bigproject.DataAccess
{
    public class DisplayElectricCar : IDisplayElectricCar
    {
        public Electric_Car GetElectricCarById(string electricCarId)
        {
            ConnectionString myConnectionString = new ConnectionString();
            string cs = myConnectionString.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * FROM electricCars WHERE electricCarId = @electricCarId";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@electricCarId", electricCarId);

            using MySqlDataReader reader = cmd.ExecuteReader();

            Electric_Car myElectricCar = null;

            if (reader.Read())
            {
                myElectricCar = new Electric_Car
                {
                    ElectricCarId = reader["electricCarId"].ToString(),
                    Make = reader["make"].ToString(),
                    Model = reader["model"].ToString(),
                    Year = Convert.ToInt32(reader["electricCarYear"]),
                    Range = Convert.ToInt32(reader["electricCarRange"]),
                    Price = Convert.ToDouble(reader["price"]),
                    KWH = Convert.ToDouble(reader["kwh"]),
                    AddOn = reader["addOn"].ToString()
                };
            }

            return myElectricCar;
        }

        void IDisplayElectricCar.DisplayElectricCar(string Electric_Id)
        {
            throw new NotImplementedException();
        }
    }
}
