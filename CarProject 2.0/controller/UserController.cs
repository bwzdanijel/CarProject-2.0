using CarProject_2._0.model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject_2._0.controller
{
    class UserController
    {
        private UserModel userHandler;

        public UserController()
        {
            DbAccess dbAccess = new DbAccess();
            userHandler = new UserModel(dbAccess);

            // Move user insertion to a method or constructor
            InsertInitialUsers();
        }

        // Method to insert initial users
        private void InsertInitialUsers()
        {
            User user1 = new User("1", "user1", "password1");
            User user2 = new User("2", "user2", "password2");

            User[] usersToInsert = new User[] { user1, user2 };
            userHandler.InsertUsers(usersToInsert);
        }


        public bool Login(string username, string password)
        {
            return userHandler.AuthenticateUser(username, password);
        }
    }
}
