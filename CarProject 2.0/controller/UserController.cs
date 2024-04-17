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
    public class UserController
    {
        private UserModel userHandler;

        public UserController()
        {
            DbAccess dbAccess = new DbAccess();
            userHandler = new UserModel(dbAccess);
        }

        public void InsertInitialUsers()
        {
            User user1 = new User("user1", "password1", "Admin", 23420);
            User user2 = new User("user2", "password2", "Player", 23420);

            User[] usersToInsert = new User[] { user1, user2 };
            userHandler.AddUser(usersToInsert);
        }

        /*
        public bool Login(string username, string password)
        {
            return userHandler.AuthenticateUser(username, password);
        }

        */

        public User AuthenticateUser(string username, string password)
        {
            return userHandler.AuthenticateUser(username, password);
        }
    }
}