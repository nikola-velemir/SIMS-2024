﻿using App.Back.Domain;
using App.Front.ViewModels.ViewControllers;
using System.Windows;

namespace App.Front.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public LoginViewModel LoginViewModel { get; set; }
        public Login()
        {
            InitializeComponent();
            LoginViewModel = new();

            DataContext = this;
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {

            var user = LoginViewModel.Login(PasswordBox.Password.Trim());
            // call constructor for any type instead of messages 
            var loginSuccessful = false;
            if(user == null) { MessageBox.Show("You do not have an account"); }
            else if (user.AccountType == AccountType.User) { var UserWindow = new UserView(user); UserWindow.Show(); loginSuccessful = true; }
            else if (user.AccountType == AccountType.Admin) { var AdminWindow = new AdministratorView(); AdminWindow.Show(); loginSuccessful = true; }
            else if (user.AccountType == AccountType.Editor) { var MusicalEditorWindow = new MusicalEditorView(user); MusicalEditorWindow.Show(); loginSuccessful = true; }
            if(loginSuccessful) { DialogResult = true; }
        }

        private void Registrate(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.ShowDialog();
        }
    }
}
