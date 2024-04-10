using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject_2._0.model
{
    class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }
    }
}
