using App.Back.Domain;
using App.Front.ViewModels.DTO;
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
    /// Interaction logic for CreateMusicEditorView.xaml
    /// </summary>
    public partial class CreateMusicEditorView : Window
    {
        public MusicEditorDTO CurrentMusicEditor { get; set; }
        private MusicEditorViewModel _musicEditorViewModel;
        private RegistrationViewModel _registrationViewModel;

        public IEnumerable<MusicalGenreDTO> AllGenres {  get; set; }
        private bool update = false;

        private void SetOptionsComboBox()
        {
            foreach (var level in Enum.GetValues(typeof(Genders)))
            {
                
                GenderComboBox.Items.Add(level);
            }
            if (update)
            {
                GenderComboBox.SelectedItem = CurrentMusicEditor.Person.Gender;
            }
            
        }

        private void SetMusicGenres()
        {
            GenresListBox.Items.Clear();

            foreach (var musicGenre in AllGenres)
            {
                GenresListBox.Items.Add(musicGenre);
            }
            foreach (var genre in CurrentMusicEditor.Genres)
            {
                if (GenresListBox.Items.Contains(genre))
                {
                    GenresListBox.SelectedItems.Add(genre);
                }
            }
        }
        public CreateMusicEditorView(MusicEditorDTO? musicEditor)
        {
            InitializeComponent();
            _musicEditorViewModel = new MusicEditorViewModel();
            _registrationViewModel = new RegistrationViewModel();
            if (musicEditor != null )
            {
                CurrentMusicEditor = new MusicEditorDTO(musicEditor);
                update = true;
            }
            else
            {
                CurrentMusicEditor = new MusicEditorDTO();
            }
            AllGenres = _musicEditorViewModel.GetAllGenres();
            SetOptionsComboBox();
            SetBirthDateTime();
            SetMusicGenres();
            DataContext = this;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }



        private void GetBirthDateTime()
        {
            string? date = BirthDateTimePicker.SelectedDate.ToString();
            try
            {
                DateTime dateTime = DateTime.Parse(date.Split(" ")[0]);
                CurrentMusicEditor.Person.BirthDate = dateTime;
            }
            catch (Exception)
            {
                
                CurrentMusicEditor.Person.BirthDate = DateTime.MinValue;
            }
        }

        private void SetBirthDateTime()
        {
            BirthDateTimePicker.Text = CurrentMusicEditor.Person.BirthDate.ToString();
        }


        private void GetSelectedGenres()
        {
            if (GenresListBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("Choose at least one music genre!");
                return;
            }
            var genres = new List<MusicalGenreDTO>();
            foreach(var item in GenresListBox.SelectedItems)
            {
                genres.Add((MusicalGenreDTO)item);
            }

            CurrentMusicEditor.Genres = genres;
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            GetBirthDateTime();
            GetSelectedGenres();
            if (GenderComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("You have to choose a gender");
                return;
            }
            CurrentMusicEditor.Person.Gender = (Genders)GenderComboBox.SelectedIndex;
            if (!_registrationViewModel.CanUserRegistrate(CurrentMusicEditor.UserAccount))
            {
                MessageBox.Show("Username already exist");
                return;
            }
            if (update)
            {

                if (CurrentMusicEditor.IsValid)
                {
                    _musicEditorViewModel.Update(CurrentMusicEditor);
                    MessageBox.Show("You successfully update music editor");
                    Close();
                }
            }
            else
            {
                if (CurrentMusicEditor.IsValid)
                {
                    _musicEditorViewModel.Create(CurrentMusicEditor);
                    MessageBox.Show("You successfully add new music editor");
                    Close();
                }
            }
            
        }
    }
}
