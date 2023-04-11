using Bigproject.Models;
using Bigproject.DataAccess;

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