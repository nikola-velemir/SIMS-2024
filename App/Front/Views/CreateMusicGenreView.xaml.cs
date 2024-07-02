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
        private bool update = false;
        public CreateMusicGenreView(MusicalGenreDTO? musicalGenre)
        {
            InitializeComponent();
            _musicalGenreViewModel = new MusicalGenreViewModel();
            if(musicalGenre != null )
            {
                CurrentMusicalGenre = new MusicalGenreDTO(musicalGenre.ToMusicGenre());
                update = true;
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
                if (update)
                {
                    var updateGenre = _musicalGenreViewModel.Update(CurrentMusicalGenre);
                    if (updateGenre != null)
                    {
                        MessageBox.Show("You successfuly update music genre");
                        Close();
                    }
                }
                else
                {
                    var genre = _musicalGenreViewModel.Create(CurrentMusicalGenre);
                    if (genre != null)
                    {
                        MessageBox.Show("You successfuly create new music genre");
                        Close();
                    }
                }
                
            }
            
        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
