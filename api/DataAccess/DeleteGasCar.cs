using Bigproject.Interfaces;
using Bigproject.Models;
using MySql.Data.MySqlClient;
using System;

namespace Bigproject.DataAccess
{
    public class DeleteGasCar : IDeleteGasCar
    {
        public static void DropGasCarTable()
        {
            ConnectionString myConnectionString = new ConnectionString();
            string cs = myConnectionString.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS gasCars";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        public void DeleteGasCarByID(string id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DELETE FROM gasCars WHERE gasCarId = @gasCarId";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@gasCarId", id);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        void IDeleteGasCar.DeleteGasCar(string Gas_Id)
        {
            throw new NotImplementedException();
        }
    }
}