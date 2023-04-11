using Bigproject.Models;

namespace Bigproject.Interfaces
{
    public interface ISaveAdmin
    {
        public void CreateAdmin(Admin myAdmin);
        public void SaveAdmin(Admin myAdmin);
    }
}