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

namespace App.Front.Views
{
    /// <summary>
    /// Interaction logic for CrudBandView.xaml
    /// </summary>
    public partial class CrudBandView : Window
    {
        BandViewModel bandViewModel = new BandViewModel();
        public CrudBandView()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {

            dataBands.ItemsSource = bandViewModel.GetAllBands();
        }



        private void Reset()
        {

            txtBoxName.Text = null;
            txtBoxDescription.Text = null;
            txtBoxBiographyText.Text = null;
            LoadData();
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            if (dataBands.SelectedItem != null)
            {
                Band band = (Band)dataBands.SelectedItem;
                band.Name = txtBoxName.Text;
                band.Description = txtBoxDescription.Text;
                band.Biography.Text = txtBoxBiographyText.Text;

                bandViewModel.UpdateBand((Band)dataBands.SelectedItem);
                MessageBox.Show("Band updated successfully!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                Reset();
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
                
            }

        }

    }
}
