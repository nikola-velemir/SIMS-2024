using App.Front.ViewModels.Presentation;
using App.Front.ViewModels.ViewControllers;
using System.Windows;
using System.Windows.Controls;

namespace App.Front.Views
{
    /// <summary>
    /// Interaction logic for UserLibrary.xaml
    /// </summary>
    public partial class UserLibrary : Window
    {
        public UserLibraryViewModel ViewModel { get; set; }
        public UserLibrary(UserAccountViewModel account)
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

        private void CreatePlaylist(object sender, RoutedEventArgs e)
        {
            var window = new CreatePlayList(ViewModel.Account);
            window.ShowDialog();
            ViewModel.Fill();
        }

        private void PlayListClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(sender == null) { return; }

            if (sender is ContentPresenter contentPresenter)
            {
                var clickedItem = contentPresenter.DataContext as PlayListViewModel; 
                if (clickedItem != null)
                {
                    var edit = new EditPlayList(ViewModel.Account,clickedItem);
                    edit.Show();
                    Close();
                }
            }

        }
    }
}
