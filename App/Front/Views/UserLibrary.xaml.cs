using App.Front.ViewModels.ViewControllers;
using System.Windows;

namespace App.Front.Views
{
    /// <summary>
    /// Interaction logic for UserLibrary.xaml
    /// </summary>
    public partial class UserLibrary : Window
    {
        public UserLibraryViewModel ViewModel { get; set; }
        public UserLibrary(UserAccountDTO account)
        {
            InitializeComponent();

            DataContext = this;
            ViewModel = new UserLibraryViewModel(account);
        }

        private void OpenHome(object sender, RoutedEventArgs e)
        {
            var home = new UserView(ViewModel.Account);
            home.Show();
            Close();
        }
    }
}
