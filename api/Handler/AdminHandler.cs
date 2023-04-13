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
            List<Admin> admins = new List<Admin>();

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
                admins.Add(admin);
            }

            return admins;
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
            allAdmins.RemoveAt(index);

            SaveAdmin saveAdmin = new SaveAdmin();
            saveAdmin.UpdateAdmin(editAdmin);
            allAdmins.Add(editAdmin);
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