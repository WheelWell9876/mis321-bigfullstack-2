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
            // List<User> users = new List<User>();
            allUsers.Clear();

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
                allUsers.Add(user);
            }

            return allUsers;
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

            SaveUser saveUser = new SaveUser();
            saveUser.UpdateUser(editUser);
            allUsers[index] = editUser; // Replace the item at the same index
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