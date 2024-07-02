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
        public UserView(UserAccountDTO account)
        {
            InitializeComponent();
            DataContext = this;

            ViewModel = new(account);
        }

        private void OpenLibrary(object sender, RoutedEventArgs e)
        {
            var library = new UserLibrary(ViewModel.Account);
            library.Show();
            Close();
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            var window = new CreatePlayList(ViewModel.Account);
            window.ShowDialog();
            OpenLibrary(sender, e);
        }
    }
}
