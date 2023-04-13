using Bigproject.Models;
using Bigproject.DataAccess;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Bigproject.Handler
{
    public class AdminHandler
    {
        public static List<Admin> allAdmins = new List<Admin>();

        public AdminHandler()
        {

        }

        public List<Admin> GetAllAdmins()
        {
            // List<Admin> admins = new List<Admin>();
            allAdmins.Clear();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM admin";

            using var cmd = new MySqlCommand(stm, con);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Admin admin = new Admin
                {
                    AdminId = reader.GetString("adminID"),
                    Email = reader.GetString("adminEmail"),
                    Password = reader.GetString("adminPassword"),
                    SecurityKey = reader.GetString("adminSecurityKey"),
                };
                allAdmins.Add(admin);
            }

            return allAdmins;
        }

        public void AddAdmin(Admin newAdmin)
        {
            SaveAdmin saveAdmin = new SaveAdmin();
            saveAdmin.CreateAdmin(newAdmin);
            allAdmins.Add(newAdmin);
        }

        public void EditAdmin(string id, Admin editAdmin)
        {
            int index = allAdmins.FindIndex(s => s.AdminId == id);

            SaveAdmin saveAdmin = new SaveAdmin();
            saveAdmin.UpdateAdmin(editAdmin);
            allAdmins[index] = editAdmin; // Replace the item at the same index
        }

        public void DeleteAdmin(string id)
        {
            int index = allAdmins.FindIndex(s => s.AdminId == id);
            allAdmins.RemoveAt(index);

            DeleteAdmin deleteAdmin = new DeleteAdmin();
            deleteAdmin.DeleteAdminByID(id);
        }
    }
}