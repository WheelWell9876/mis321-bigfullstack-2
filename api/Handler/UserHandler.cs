using Bigproject.Models;
using Bigproject.DataAccess;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Bigproject.Handler
{
    public class UserHandler
    {
        public static List<User> allUsers = new List<User>();

        public UserHandler()
        {

        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM users";

            using var cmd = new MySqlCommand(stm, con);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                User user = new User
                {
                    UserId = reader.GetString("userID"),
                    Email = reader.GetString("userEmail"),
                    Password = reader.GetString("userPassword"),
                };
                users.Add(user);
            }

            return users;
        }

        public void AddUser(User newUser)
        {
            SaveUser saveUser = new SaveUser();
            saveUser.CreateUser(newUser);
            allUsers.Add(newUser);
        }

        public void EditUser(string id, User editUser)
        {
            int index = allUsers.FindIndex(s => s.UserId == id);
            allUsers.RemoveAt(index);

            SaveUser saveUser = new SaveUser();
            saveUser.UpdateUser(editUser);
            allUsers.Add(editUser);
        }

        public void DeleteUser(string id)
        {
            int index = allUsers.FindIndex(s => s.UserId == id);
            allUsers.RemoveAt(index);

            DeleteUser deleteUser = new DeleteUser();
            deleteUser.DeleteUserByID(id);
        }
    }
}