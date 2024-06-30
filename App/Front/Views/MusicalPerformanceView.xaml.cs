using App.Back.Domain;
using App.Front.ViewModels.Presentation;
using App.Front.ViewModels.ViewControllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MusicalPerformanceView.xaml
    /// </summary>
    public partial class MusicalPerformanceView : Window
    {
        public PictureViewModel CurrentPicture {  get; set; }        
        public MusicalPerformanceDataViewModel CurrentMusicalPerformance {  get; set; }
        private MusicalPerformanceViewModel _musicalPerformanceViewModel { get; set; }

        private void SetComboBoxOptions()
        {
            var genres = _musicalPerformanceViewModel.GetAllMusicalGenre();
            foreach(var musicalGenre in genres)
            {
                GenreComboBox.Items.Add(musicalGenre.Name);
            }
        }
        public MusicalPerformanceView()
        {
            InitializeComponent();
            CurrentPicture = new PictureViewModel();
            CurrentMusicalPerformance = new MusicalPerformanceDataViewModel();
            _musicalPerformanceViewModel = new MusicalPerformanceViewModel();
            SetComboBoxOptions();
            DataContext = this;
        }

        private void AddPictureClick(object sender, RoutedEventArgs e)
        {
            if (CurrentPicture.IsValid)
            {
                Picture? picture = _musicalPerformanceViewModel.CreatePicture(CurrentPicture.ToPicture());
                if(picture != null)
                {
                    CurrentMusicalPerformance.AddPicture(picture);
                }
            }
            PicturesDataGrid.Items.Refresh();
            PicturePathTextBox.Clear();
            PictureDescriptionTextBox.Clear();
        }

        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            if(GenreComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Musical performance must hava a genre!");
                return;
            }
            var genreId = _musicalPerformanceViewModel.GetIdByGenreName(GenreComboBox.SelectedValue.ToString());
            CurrentMusicalPerformance.MusicalGenreId = genreId;
            if (CurrentMusicalPerformance.IsValid)
            {
                MusicalPiece? musicalPerformance = _musicalPerformanceViewModel.CreateMusicalPerformance(CurrentMusicalPerformance.ToMusicalPerformance());
                if(musicalPerformance != null)
                {
                    MessageBox.Show("You successfuly add new musical performance!");
                    this.Close();
                }
            }
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
