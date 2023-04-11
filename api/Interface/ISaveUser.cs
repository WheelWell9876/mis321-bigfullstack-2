using Bigproject.Models;

namespace Bigproject.Interfaces
{
    public interface ISaveUser
    {
        public void CreateUser(User myUser);
        public void SaveUser(User myUser);
    }
}