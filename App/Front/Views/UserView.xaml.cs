using App.Front.ViewModels.ViewControllers;
using System.Windows;

namespace App.Front.Views
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : Window
    {
        public UserViewViewModel ViewModel { get; set; }
        public UserView()
        {
            InitializeComponent();
            DataContext = this;

            ViewModel = new();
        }
    }
}
