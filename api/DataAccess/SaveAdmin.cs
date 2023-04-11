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

            string stm = @"CREATE TABLE admin(adminId VARCHAR(255) PRIMARY KEY, email TEXT, massword TEXT, securityKey TEXT)";

            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }

        public void CreateAdmin(Admin myAdmin)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO admin(adminId, email, massword, securityKey) VALUES(@adminId, @email, @massword, @securityKey)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@adminId", myAdmin.AdminId);
            cmd.Parameters.AddWithValue("@email", myAdmin.Email);
            cmd.Parameters.AddWithValue("@massword", myAdmin.Massword);
            cmd.Parameters.AddWithValue("@securityKey", myAdmin.SecurityKey);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        public void UpdateAdmin(Admin myAdmin)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE admin SET email = @email, massword = @massword, securityKey = @securityKey WHERE adminId = @adminId";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@adminId", myAdmin.AdminId);
            cmd.Parameters.AddWithValue("@email", myAdmin.Email);
            cmd.Parameters.AddWithValue("@massword", myAdmin.Massword);
            cmd.Parameters.AddWithValue("@securityKey", myAdmin.SecurityKey);

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
                    adminId VARCHAR(255) PRIMARY KEY,
                    email TEXT NOT NULL,
                    massword TEXT NOT NULL,
                    securityKey TEXT NOT NULL
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

            string stm = "SELECT * FROM admin WHERE adminId = @adminId";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@adminId", id);
            cmd.Prepare();

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Admin admin = new Admin
                {
                    AdminId = reader.GetString("adminId"),
                    Email = reader.GetString("email"),
                    Massword = reader.GetString("massword"),
                    SecurityKey = reader.GetString("securityKey"),
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