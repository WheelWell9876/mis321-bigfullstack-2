using Bigproject.Models;
using Bigproject.DataAccess;

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