using Bigproject.Interfaces;
using Bigproject.Models;
using MySql.Data.MySqlClient;
using System;

namespace Bigproject.DataAccess
{
    public class DeleteAdmin : IDeleteAdmin
    {
        public static void DropAdminTable()
        {
            ConnectionString myConnectionString = new ConnectionString();
            string cs = myConnectionString.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS admin";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        } 

        public void DeleteAdminByID(string id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DELETE FROM admin WHERE adminId = @adminId";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@adminId", id);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        void IDeleteAdmin.DeleteAdmin(string Admin_Id)
        {
            throw new NotImplementedException();
        }
    }
}