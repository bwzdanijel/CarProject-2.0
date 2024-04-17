using CarProject_2._0.controller;
using CarProject_2._0.model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarProject_2._0
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private UserController userController;

        public Login()
        {
            InitializeComponent();
            userController = new UserController();
        }

        public Login(UserController userController)
        {
            InitializeComponent();
            this.userController = userController;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            User authenticatedUser = userController.AuthenticateUser(username, password);

            if (authenticatedUser != null)
            {
                MainWindow mainWindow = new MainWindow(authenticatedUser.Id); // Übergebe die UserId anstatt des gesamten User-Objekts
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}