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

        private void KreiraIzvodjacaClick(object sender, RoutedEventArgs e)
        {
            var window = new KreiranjeIzvodjaca();
            window.ShowDialog();
        }
    }
}