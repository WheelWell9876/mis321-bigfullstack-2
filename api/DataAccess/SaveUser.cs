using Bigproject.Interfaces;
using Bigproject.Models;
using MySql.Data.MySqlClient;

namespace Bigproject.DataAccess
{
    public class SaveUser : ISaveUser
    {
        public static void CreateUserTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE users(userID VARCHAR(255) PRIMARY KEY, userEmail TEXT, userPassword TEXT)";

            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }

        public void CreateUser(User myUser)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO users(userID, userEmail, userPassword) VALUES(@userID, @userEmail, @userPassword)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@userID", myUser.UserId);
            cmd.Parameters.AddWithValue("@userEmail", myUser.Email);
            cmd.Parameters.AddWithValue("@userPassword", myUser.Password);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        public void UpdateUser(User myUser)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE users SET userEmail = @userEmail, userPassword = @userPassword WHERE userID = @userID";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@userID", myUser.UserId);
            cmd.Parameters.AddWithValue("@userEmail", myUser.Email);
            cmd.Parameters.AddWithValue("@userPassword", myUser.Password);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        void ISaveUser.SaveUser(User myUser)
        {
            throw new NotImplementedException();
        }

        public void InitializeDatabase()
        {
            string sql = @"USE p6nr5re8fmcvgnki;

                CREATE TABLE IF NOT EXISTS users (
                    userID VARCHAR(255) PRIMARY KEY,
                    userEmail TEXT NOT NULL,
                    userPassword TEXT NOT NULL
                );

                SELECT * FROM p6nr5re8fmcvgnki.users;";

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            using var cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public User GetUserById(string id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM users WHERE userID = @userID";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@userID", id);
            cmd.Prepare();

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                User user = new User
                {
                    UserId = reader.GetString("userID"),
                    Email = reader.GetString("userEmail"),
                    Password = reader.GetString("userPassword"),
                };
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
