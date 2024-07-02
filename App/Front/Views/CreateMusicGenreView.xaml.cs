using App.Front.ViewModels.DTO;
using App.Front.ViewModels.Presentation;
using App.Front.ViewModels.ViewControllers;
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
    /// Interaction logic for CreateMusicGenreView.xaml
    /// </summary>
    public partial class CreateMusicGenreView : Window
    {
        private MusicalGenreViewModel _musicalGenreViewModel;
        public MusicalGenreDTO CurrentMusicalGenre { get; set; }    
        public CreateMusicGenreView(MusicalGenreDTO? musicalGenre)
        {
            InitializeComponent();
            _musicalGenreViewModel = new MusicalGenreViewModel();
            if(musicalGenre != null )
            {
                CurrentMusicalGenre = new MusicalGenreDTO(musicalGenre.ToMusicGenre());
            }
            else
            {
                CurrentMusicalGenre = new MusicalGenreDTO();
            }
            DataContext = this;
        }

        private void Create_Button(object sender, RoutedEventArgs e)
        {
            if (CurrentMusicalGenre.IsValid)
            {
                var genre = _musicalGenreViewModel.Create(CurrentMusicalGenre);
                if(genre != null )
                {
                    MessageBox.Show("You successfuly create new musical genre");
                    Close();
                }
            }
            
        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
