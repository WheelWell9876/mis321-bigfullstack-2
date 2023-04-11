using Bigproject.Interfaces;
using Bigproject.Models;
using MySql.Data.MySqlClient;
using System;

namespace Bigproject.DataAccess
{
    public class DeleteCarPair : IDeleteCarPair
    {
        public static void DropCarPairTable()
        {
            ConnectionString myConnectionString = new ConnectionString();
            string cs = myConnectionString.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS car_pairs";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        public void DeleteCarPairByID(string id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DELETE FROM car_pairs WHERE pairId = @pairId";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@pairId", id);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}