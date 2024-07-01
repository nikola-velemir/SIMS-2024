using App.Front.ViewModels.Presentation;
using System.Windows;

namespace App.Front.Views
{
    /// <summary>
    /// Interaction logic for CreatePlayListView.xaml
    /// </summary>
    public partial class EditPlayList : Window
    {
        public EditPlayListViewViewModel ViewModel { get; set; }
        public EditPlayList(UserAccountViewModel account, PlayListViewModel playList)
        {
            InitializeComponent();
            DataContext = this;

            ViewModel = new(account, playList);
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
            ViewModel.AddPieces();
        }

        private void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            ViewModel.RemovePiece();
        }

        private void OpenCreatePlayList(object sender, RoutedEventArgs e)
        {
            var window = new CreatePlayList(ViewModel.Account);
            window.ShowDialog();

            OpenLibrary(sender,e);
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
