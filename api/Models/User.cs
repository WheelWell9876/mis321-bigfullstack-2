using Bigproject.DataAccess;
using Bigproject.Interfaces;

namespace Bigproject.Models
{
    public class User
    {
        public string UserId {get; set;}
        public string Email {get; set;}
        public string Massword {get; set;}

        public ISaveUser SaveUser {get; set;}

        public User()
        {
            UserId = Guid.NewGuid().ToString();
            SaveUser = new SaveUser();
        }

        public override string ToString()
        {
            return $"{Email} {Massword}";
        }
    }
}