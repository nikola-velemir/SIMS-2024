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
            if(user == null) { MessageBox.Show("You do not have an account"); }
            else if (user.Type == AccountType.User) { var UserWindow = new UserView(new UserAccountViewModel(user)); UserWindow.Show(); Close(); }
            else if (user.Type == AccountType.Admin) { MessageBox.Show("Welcome admin"); }
            else if (user.Type == AccountType.Editor) { MessageBox.Show("Welcome editor"); }

        }

        private void Registrate(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.ShowDialog();

        }
    }
}
