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
        public UserView(UserAccountViewModel account)
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

        private void CreatePlayList(object sender, RoutedEventArgs e)
        {
            var createPlaylist = new CreatePlayListView(ViewModel.Account);
            createPlaylist.Show();
            Close();
        }
    }
}
