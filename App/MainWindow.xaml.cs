using App.Back.Service;
using App.Front.Views;
using System.Windows;
namespace App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            var window = new Login();
            var a = window.ShowDialog();
            if (a != null && a == true) { Close(); }
        }
    }
}