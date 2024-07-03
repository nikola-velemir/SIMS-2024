using App.Back.Domain;
using App.Front.ViewModels.ViewControllers;
using System.Windows;

namespace App.Front.Views
{
    /// <summary>
    /// Interaction logic for KreiranjeIzvodjaca.xaml
    /// </summary>
    public partial class PerformerCreation : Window
    {
        public PerformerCreationViewModel ViewModel { get; set; }
        public PerformerCreation()
        {
            InitializeComponent();
            DataContext = this;


            ViewModel = new();
            PolComboBox.ItemsSource = Enum.GetValues(typeof(Genders)).Cast<Genders>();
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Submit()) { Close(); }
        }
    }
}
