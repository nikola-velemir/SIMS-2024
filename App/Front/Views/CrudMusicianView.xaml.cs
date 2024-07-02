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
using App.Back.Domain.Osobe;
using App.Back.Domain;

namespace App.Front.Views
{
    /// <summary>
    /// Interaction logic for CrudMusicianView.xaml
    /// </summary>
    public partial class CrudMusicianView : Window
    {
        MusicianViewModel musicianViewModel = new MusicianViewModel();
        public CrudMusicianView()
        {
            InitializeComponent();
            LoadData();
            SetupControls();
        }


        private void LoadData()
        {
            
            dataMusicians.ItemsSource = musicianViewModel.GetAllMusicians();
        }

        private void SetupControls()
        {
            comboBoxGender.ItemsSource = Enum.GetValues(typeof(Genders)).Cast<Genders>();
        }

        private void Reset()
        {
            comboBoxGender.SelectedItem = null;
            txtBoxFirstName.Text = null;
            txtBoxLastName.Text = null;
            txtBoxJMBG.Text = null;
            birthDatePicker.SelectedDate = null;
            LoadData();
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            if (dataMusicians.SelectedItem != null)
            {
                Performer performer = (Performer)dataMusicians.SelectedItem;
                performer.FirstName = txtBoxFirstName.Text;
                performer.LastName = txtBoxLastName.Text;
                performer.JMBG = txtBoxJMBG.Text;
                performer.BirthDate = DateOnly.FromDateTime(birthDatePicker.SelectedDate.Value);
                performer.Gender = (Genders)comboBoxGender.SelectedItem;

                musicianViewModel.UpdateMusician((Performer)dataMusicians.SelectedItem);
                MessageBox.Show("Performer updated successfully!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                Reset();
            }
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (dataMusicians.SelectedItem != null)
            {
                musicianViewModel.DeleteMusician((Performer)dataMusicians.SelectedItem);
                MessageBox.Show("Performer deleted successfully!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                Reset();
            }
        }

        private void dataMusicians_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataMusicians.SelectedItem != null)
            {
                Performer selectedPerformer = (Performer)dataMusicians.SelectedValue;
                txtBoxFirstName.Text = selectedPerformer.FirstName ?? "";
                txtBoxLastName.Text = selectedPerformer.LastName ?? "";
                txtBoxJMBG.Text = selectedPerformer.JMBG ?? "";
                comboBoxGender.SelectedItem = selectedPerformer.Gender;

                if (selectedPerformer.BirthDate != null)
                {
                    birthDatePicker.SelectedDate = selectedPerformer.BirthDate.ToDateTime(TimeOnly.MinValue);
                }
                else
                {
                    birthDatePicker.SelectedDate = null;
                }
            }
        }
    }
}
