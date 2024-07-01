using App.Front.ViewModels.ViewControllers;
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
            string user = LoginViewModel.Login();
            // call constructor for any type instead of messages 
            if(user == "") { MessageBox.Show("You do not have an account"); }
            else if (user == "Korisnik") { MessageBox.Show("Welcome user"); }
            else if (user == "Administrator") { MessageBox.Show("Welcome admin"); }
            else if (user == "MuzickiUrednik") { MessageBox.Show("Welcome reviser"); }

        }

        private void Registrate(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.ShowDialog();
        }
    }
}
