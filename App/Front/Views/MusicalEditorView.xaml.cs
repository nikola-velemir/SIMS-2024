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
        public MusicalEditorView()
        {
            InitializeComponent();
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
    }
}
