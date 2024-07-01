using System.Windows;

namespace App.Front.Views
{
    /// <summary>
    /// Interaction logic for CreatePlayListView.xaml
    /// </summary>
    public partial class CreatePlayListView : Window
    {
        public CreatePlayListViewViewModel ViewModel { get; set; }
        public CreatePlayListView(UserAccountViewModel account)
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

        private void OpenHome(object sender, RoutedEventArgs e)
        {
            var home = new UserView(ViewModel.Account);
            home.Show();
            Close();
        }
        private void AddButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void OpenCreatePlayList(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
