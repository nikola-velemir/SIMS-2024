using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace App.Front.Views
{
    /// <summary>
    /// Interaction logic for MusicalEditorView.xaml
    /// </summary>
    public partial class MusicalEditorView : Window
    {
        public UserAccountDTO UserAccount;
        public MusicalEditorView(UserAccountDTO userAccountDTO)
        {
            InitializeComponent();
            UserAccount = userAccountDTO;
            WelcomeLabel.Content = "Welcome " + UserAccount.UserName + "!";
            DataContext = this;
        }

        private void SongsOfTheYearClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Feature is not yet implemented", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void PerformersToplistClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Feature is not yet implemented", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CrudMusicalPieceClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Feature is not yet implemented", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CrudBandClick(object sender, RoutedEventArgs e)
        {
            CrudBandView crudBandView = new CrudBandView();
            crudBandView.Show();
        }

        private void CrudMusicianClick(object sender, RoutedEventArgs e)
        {
            CrudMusicianView crudMusicianView = new CrudMusicianView();
            crudMusicianView.Show();
        }

        private void ApproveCommentsClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Feature is not yet implemented", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void EditCommentsClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Feature is not yet implemented", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void MakeReviewClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Feature is not yet implemented", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ApproveReviewClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Feature is not yet implemented", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void LogoutClick(object sender, RoutedEventArgs e)
        {
            Close();
            
        }

        private void ShowCommentsOption(object sender, RoutedEventArgs e)
        {
            RefreshVisibility();
            CommentButtonsPanel.Visibility = Visibility.Visible;
        }

        private void ShowReviewsOption(object sender, RoutedEventArgs e)
        {
            RefreshVisibility();
            ReviewButtonsPanel.Visibility = Visibility.Visible;
        }

        private void ShowToplistOption(object sender, RoutedEventArgs e)
        {
            RefreshVisibility();
            ToplistButtonsPanel.Visibility = Visibility.Visible;
        }

        private void ShowEditorInfo(object sender, RoutedEventArgs e)
        {
            RefreshVisibility();
            EditorInfoButtonsPanel.Visibility = Visibility.Visible;
            WelcomeLabel.Content = "Welcome " + UserAccount.UserName + "!";
        }
        private void ShowMusicalNotionOption(object sender, RoutedEventArgs e)
        {
            RefreshVisibility();
            MusicalNotionInfoButtonsPanel.Visibility = Visibility.Visible;
        }
        private void RefreshVisibility()
        {
            CommentButtonsPanel.Visibility = Visibility.Hidden;
            ReviewButtonsPanel.Visibility = Visibility.Hidden;
            ToplistButtonsPanel.Visibility = Visibility.Hidden;
            EditorInfoButtonsPanel.Visibility = Visibility.Hidden;
            MusicalNotionInfoButtonsPanel.Visibility = Visibility.Hidden;
        }


    }
}
