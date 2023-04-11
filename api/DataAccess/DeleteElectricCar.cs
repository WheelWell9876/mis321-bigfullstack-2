using Bigproject.Interfaces;
using Bigproject.Models;
using MySql.Data.MySqlClient;
using System;

namespace Bigproject.DataAccess
{
    public class DeleteElectricCar : IDeleteElectricCar
    {
        public static void DropElectricCarTable()
        {
            ConnectionString myConnectionString = new ConnectionString();
            string cs = myConnectionString.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS electricCars";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        public void DeleteElectricCarByID(string id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DELETE FROM electricCars WHERE electricCarId = @electricCarId";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@electricCarId", id);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        void IDeleteElectricCar.DeleteElectricCar(string Electric_Id)
        {
            throw new NotImplementedException();
        }
    }
}