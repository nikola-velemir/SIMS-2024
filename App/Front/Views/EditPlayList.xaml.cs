using App.Back.Domain;
using App.Front.ViewModels.Presentation;
using App.Front.ViewModels.Presentation.Wrappers;
using System.Windows;
using System.Windows.Controls;

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
            var a = sender;
            if (sender is Button button)
            {
                // Get the DataContext of the ListViewItem associated with this button
                if (button.DataContext is MusicalPieceWrapperViewModel musicalPieceViewModel)
                {
                    ViewModel.AddPiece(musicalPieceViewModel);
                }
            }

        }

        private void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            var a = sender;
            if (sender is Button button)
            {
                // Get the DataContext of the ListViewItem associated with this button
                if (button.DataContext is MusicalPieceWrapperViewModel musicalPieceViewModel)
                {
                    ViewModel.RemovePiece(musicalPieceViewModel);
                }
            }

            //ViewModel.RemovePiece();
        }

        private void OpenCreatePlayList(object sender, RoutedEventArgs e)
        {
            var window = new CreatePlayList(ViewModel.Account);
            window.ShowDialog();

            OpenLibrary(sender, e);
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Save())
            {
                MessageBox.Show("Play list save successfuly!");

            }
            else
            {
                MessageBox.Show("Failed to save the playlist!");
            }
            OpenLibrary(sender, e);
        }
    }
}
