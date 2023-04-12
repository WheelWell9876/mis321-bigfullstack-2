using Bigproject.Interfaces;
using Bigproject.Models;
using MySql.Data.MySqlClient;

namespace Bigproject.DataAccess
{
    public class SaveAdmin : ISaveAdmin
    {
        public static void CreateAdminTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE admin(adminID VARCHAR(255) PRIMARY KEY, adminEmail TEXT, adminPassword TEXT, adminSecurityKey TEXT)";

            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }

        public void CreateAdmin(Admin myAdmin)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO admin(adminID, adminEmail, adminPassword, adminSecurityKey) VALUES(@adminID, @adminEmail, @adminPassword, @adminSecurityKey)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@adminID", myAdmin.AdminId);
            cmd.Parameters.AddWithValue("@adminEmail", myAdmin.Email);
            cmd.Parameters.AddWithValue("@adminPassword", myAdmin.Password);
            cmd.Parameters.AddWithValue("@adminSecurityKey", myAdmin.SecurityKey);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        public void UpdateAdmin(Admin myAdmin)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE admin SET adminEmail = @adminEmail, adminPassword = @adminPassword, adminSecurityKey = @adminSecurityKey WHERE adminID = @adminID";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@adminID", myAdmin.AdminId);
            cmd.Parameters.AddWithValue("@adminEmail", myAdmin.Email);
            cmd.Parameters.AddWithValue("@adminPassword", myAdmin.Password);
            cmd.Parameters.AddWithValue("@adminSecurityKey", myAdmin.SecurityKey);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        void ISaveAdmin.SaveAdmin(Admin myAdmin)
        {
            throw new NotImplementedException();
        }

        public void InitializeDatabase()
        {
            string sql = @"USE p6nr5re8fmcvgnki;

                CREATE TABLE IF NOT EXISTS admin (
                    adminID VARCHAR(255) PRIMARY KEY,
                    adminEmail TEXT NOT NULL,
                    adminPassword TEXT NOT NULL,
                    adminSecurityKey TEXT NOT NULL
                );

                SELECT * FROM p6nr5re8fmcvgnki.admin;";

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            using var cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public Admin GetAdminById(string id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM admin WHERE adminID = @adminID";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@adminID", id);
            cmd.Prepare();

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Admin admin = new Admin
                {
                    AdminId = reader.GetString("adminID"),
                    Email = reader.GetString("adminEmail"),
                    Password = reader.GetString("adminPassword"),
                    SecurityKey = reader.GetString("adminSecurityKey"),
                };
                return admin;
            }
            else
            {
                return null;
            }
        }
    }
}