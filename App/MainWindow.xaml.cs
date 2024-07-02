﻿using App.Back.Service;
using App.Front.Views;
using System.Windows;
namespace App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void KreiraIzvodjacaClick(object sender, RoutedEventArgs e)
        {
            var window = new PerformerCreation();
            window.ShowDialog();
        }
        private void KreiranjeDelaClick(object sender, RoutedEventArgs e)
        {
            MusicalPieceView musicalPieceView  = new MusicalPieceView(null);
            musicalPieceView.Show();
        }
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            var window = new Login();
            var a = window.ShowDialog();
            if (a != null && a == true) { Close(); }
        }
    }
}