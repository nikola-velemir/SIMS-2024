using App.Back.Domain.Osobe;
using App.Back.Domain;
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
using App.Back.Utilities;
using App.Front.ViewModels.DTO;

namespace App.Front.Views
{
    /// <summary>
    /// Interaction logic for CrudBandView.xaml
    /// </summary>
    public partial class CrudBandView : Window
    {
        BandViewModel bandViewModel = new BandViewModel();
        MusicalGenreViewModel musicalGenre = new MusicalGenreViewModel();
        public CrudBandView()
        {
            InitializeComponent();
            LoadData();
            SetupControls();
        }

        private void LoadData()
        {

            dataBands.ItemsSource = bandViewModel.GetAllBands();
        }

        private void SetupControls()
        {
            //List<MusicalGenreDTO> musicalGenres = musicalGenre.GetAllGenres();
            comboBoxGenre.ItemsSource = musicalGenre.GetAllGenres();
            comboBoxGenre.DisplayMemberPath = "Name";
        }



        private void Reset()
        {

            txtBoxName.Text = null;
            txtBoxDescription.Text = null;
            txtBoxBiographyText.Text = null;
            comboBoxGenre.SelectedItem = null;
            LoadData();
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            if (dataBands.SelectedItem != null && !string.IsNullOrWhiteSpace(txtBoxName.Text) &&
                !string.IsNullOrWhiteSpace(txtBoxDescription.Text) &&
                !string.IsNullOrWhiteSpace(txtBoxBiographyText.Text) &&
                comboBoxGenre.SelectedItem != null)
            {
                Band band = (Band)dataBands.SelectedItem;
                band.Name = txtBoxName.Text;
                band.Description = txtBoxDescription.Text;
                band.Biography.Text = txtBoxBiographyText.Text;
                MusicalGenreDTO selectedGenre = (MusicalGenreDTO)comboBoxGenre.SelectedItem;
                band.MusicalGenreId = selectedGenre.Id;

                bandViewModel.UpdateBand((Band)dataBands.SelectedItem);
                MessageBox.Show("Band updated successfully!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("You must select a band!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (dataBands.SelectedItem != null)
            {
                bandViewModel.DeleteBand((Band)dataBands.SelectedItem);
                MessageBox.Show("Band deleted successfully!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                Reset();
            }
            else
            {
                MessageBox.Show("You must select a band!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void dataBands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataBands.SelectedItem != null)
            {
                Band selectedBand = (Band)dataBands.SelectedValue;
                txtBoxName.Text = selectedBand.Name ?? "";
                txtBoxDescription.Text = selectedBand.Description ?? "";
                txtBoxBiographyText.Text = selectedBand.Biography.Text ?? "";

                var allGenres = musicalGenre.GetAllGenres();
                comboBoxGenre.ItemsSource = allGenres;
                comboBoxGenre.DisplayMemberPath = "Name";

                var selectedGenre = allGenres.FirstOrDefault(g => g.Id == selectedBand.MusicalGenreId);
                if (selectedGenre != null)
                {
                    comboBoxGenre.SelectedItem = selectedGenre;
                }


            }

        }

        private void CreateClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxName.Text) ||
                string.IsNullOrWhiteSpace(txtBoxDescription.Text) ||
                string.IsNullOrWhiteSpace(txtBoxBiographyText.Text) ||
                comboBoxGenre.SelectedItem == null
                )
            {
                MessageBox.Show("You must fill all fields!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Band newBand = new Band();
                Biography bio = new Biography();
                bio.Id = Utils.GenerateId() % 1000;
                bio.Text = txtBoxBiographyText.Text;
                newBand.Name = txtBoxName.Text;
                newBand.Description = txtBoxDescription.Text;
                newBand.Biography = bio;
                newBand.ProfileImageId = -1;
                MusicalGenreDTO selectedGenre = (MusicalGenreDTO)comboBoxGenre.SelectedItem;
                newBand.MusicalGenreId = selectedGenre.Id;
                bandViewModel.CreateBand(newBand);
                MessageBox.Show("Band created successfully!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                Reset();
            }
        }
    }
}
