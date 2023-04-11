using Bigproject.Interfaces;
using Bigproject.Models;
using MySql.Data.MySqlClient;
using System;

namespace Bigproject.DataAccess
{
    public class DeleteUser : IDeleteUser
    {
        public static void DropUserTable()
        {
            ConnectionString myConnectionString = new ConnectionString();
            string cs = myConnectionString.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS users";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        public void DeleteUserByID(string id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DELETE FROM users WHERE userId = @userId";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@userId", id);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        void IDeleteUser.DeleteUser(string User_Id)
        {
            throw new NotImplementedException();
        }
    }
}