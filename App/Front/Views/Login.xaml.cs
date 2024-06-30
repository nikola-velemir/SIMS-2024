using App.Front.ViewModels.ViewControllers;
using System.Windows;

namespace App.Front.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public LoginViewModel ViewModel { get; set; }
        public Login()
        {
            InitializeComponent();
            DataContext = this;

            ViewModel = new();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            ViewModel.Nalog.Lozinka = LozinkaPasswordBox.Password;
            var nalog = ViewModel.Login();
            if (nalog != null) { MessageBox.Show("Welcome " + ViewModel.Nalog.KorisnickoIme + "!"); }
            var window = new UserView();
            window.Show();
            Close();
        }
    }
}
