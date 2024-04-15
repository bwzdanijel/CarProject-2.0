using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarProject_2._0.model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Balance { get; set; }

        public User() { }

        public User(string name, string password, string role, int balance)
        {
            Name = name;
            Password = password;
            Role = role;
            Balance = balance;
        }
    }
}
