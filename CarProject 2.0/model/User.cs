using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject_2._0.model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }


        public User(string name, int balance) 
        {
            Name = name;
            Balance = balance;
        }
    }
}
