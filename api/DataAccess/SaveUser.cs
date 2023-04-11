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

            string stm = @"CREATE TABLE users(userId VARCHAR(255) PRIMARY KEY, email TEXT, massword TEXT)";

            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }

        public void CreateUser(User myUser)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO users(userId, email, massword) VALUES(@userId, @email, @massword)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@userId", myUser.UserId);
            cmd.Parameters.AddWithValue("@email", myUser.Email);
            cmd.Parameters.AddWithValue("@massword", myUser.Massword);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        public void UpdateUser(User myUser)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE users SET email = @email, massword = @massword WHERE userId = @userId";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@userId", myUser.UserId);
            cmd.Parameters.AddWithValue("@email", myUser.Email);
            cmd.Parameters.AddWithValue("@massword", myUser.Massword);

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
                    userId VARCHAR(255) PRIMARY KEY,
                    email TEXT NOT NULL,
                    massword TEXT NOT NULL
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

            string stm = "SELECT * FROM users WHERE userId = @userId";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@userId", id);
            cmd.Prepare();

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                User user = new User
                {
                    UserId = reader.GetString("userId"),
                    Email = reader.GetString("email"),
                    Massword = reader.GetString("massword"),
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
