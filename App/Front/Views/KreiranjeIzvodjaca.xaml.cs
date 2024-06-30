using App.Back.Domain;
using App.Front.ViewModels.ViewControllers;
using System.Windows;

namespace App.Front.Views
{
    /// <summary>
    /// Interaction logic for KreiranjeIzvodjaca.xaml
    /// </summary>
    public partial class KreiranjeIzvodjaca : Window
    {
        public KreiranjeIzvodjacaViewModel ViewModel { get; set; }
        public KreiranjeIzvodjaca()
        {
            InitializeComponent();
            DataContext = this;

            ViewModel = new();
            PolComboBox.ItemsSource = Enum.GetValues(typeof(Polovi)).Cast<Polovi>();
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Submit()) { Close(); }
        }
    }
}
