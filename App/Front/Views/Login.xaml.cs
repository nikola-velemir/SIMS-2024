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
            ViewModel.Account.Password = LozinkaPasswordBox.Password;
            var nalog = ViewModel.Login();
            if (nalog != null)
            {
                MessageBox.Show("Welcome " + ViewModel.Account.UserName + "!");
                var window = new UserView(new UserAccountViewModel(nalog));
                window.Show();
                Close();
            }
        }
    }
}
