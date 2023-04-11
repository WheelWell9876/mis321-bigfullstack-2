using System;
using Bigproject.DataAccess;
using Bigproject.Interfaces;
using System.Text.Json.Serialization;

namespace Bigproject.Models
{
    public class Admin
    {
        public string AdminId { get; set; }
        public string Email { get; set; }
        public string Massword { get; set; }
        public string SecurityKey { get; set; }

        public ISaveAdmin SaveAdmin { get; set; }

        public Admin()
        {
            AdminId = Guid.NewGuid().ToString();
            SaveAdmin = new SaveAdmin();
        }

        public override string ToString()
        {
            return $"{Email} {Massword} {SecurityKey}";
        }
    }
}