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

            string stm = @"SELECT * FROM electricCars WHERE electricCarID = @electricCarID";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@electricCarID", electricCarId);

            using MySqlDataReader reader = cmd.ExecuteReader();

            Electric_Car myElectricCar = null;

            if (reader.Read())
            {
                myElectricCar = new Electric_Car
                {
                    ElectricCarId = reader["electricCarID"].ToString(),
                    Make = reader["electricCarMake"].ToString(),
                    Model = reader["electricCarModel"].ToString(),
                    Year = Convert.ToInt32(reader["electricCarYear"]),
                    Range = Convert.ToInt32(reader["electricCarRange"]),
                    Price = Convert.ToDouble(reader["electricCarPrice"]),
                    KWH = Convert.ToDouble(reader["electricCarKwh"]),
                    AddOn = reader["electricCarAddOn"].ToString()
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
