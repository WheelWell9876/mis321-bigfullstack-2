using Bigproject.Interfaces;
using Bigproject.Models;
using MySql.Data.MySqlClient;
using System;

namespace Bigproject.DataAccess
{
    public class DisplayGasCar : IDisplayGasCar
    {
        public Gas_Car GetGasCarById(string gasCarId)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * FROM gasCars WHERE gasCarID = @gasCarID";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@gasCarID", gasCarId);

            using MySqlDataReader reader = cmd.ExecuteReader();

            Gas_Car myGasCar = null;

            if (reader.Read())
            {
                myGasCar = new Gas_Car
                {
                    GasCarId = reader["gasCarID"].ToString(),
                    Make = reader["gasCarMake"].ToString(),
                    Model = reader["gasCarModel"].ToString(),
                    Year = Convert.ToInt32(reader["gasCarYear"]),
                    Range = Convert.ToInt32(reader["gasCarRange"]),
                    Price = Convert.ToDouble(reader["gasCarPrice"]),
                    MPG = Convert.ToDouble(reader["gasCarMpg"]),
                    AddOn = reader["gasCarAddOn"].ToString()
                };
            }

            return myGasCar;
        }

        void IDisplayGasCar.DisplayGasCar(string Gas_Id)
        {
            throw new NotImplementedException();
        }
    }
}
