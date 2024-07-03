using App.Back.Service;
using App.Front.ViewModels.ViewControllers;
using App.Front.Views;
using System.Security.Principal;
using System.Windows;
namespace App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserViewViewModel UserWindowViewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            UserWindowViewModel = new UserViewViewModel();
            DataContext = this;
        }
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            var window = new Login();
            var a = window.ShowDialog();
            if (a != null && a == true) 
            { 
                Close(); 
            }
        }
    }
}