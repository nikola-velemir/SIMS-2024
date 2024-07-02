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
    /// Interaction logic for CreatePlayList.xaml
    /// </summary>
    public partial class CreatePlayList : Window
    {
        public CreatePlayListViewModel ViewModel { get; set; }
        public CreatePlayList(UserAccountDTO account)
        {
            InitializeComponent();
            DataContext = this;

            ViewModel = new(account);
        }

        private void CreateClick(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Create())
            {
                MessageBox.Show("Play list " + ViewModel.PlayList.Name + " created!");
                
                Close();
                return;
            }
            MessageBox.Show("Failed to create a playlist!");

            var library = new UserLibrary(ViewModel.Account);
            library.Show();
            Close();
        }
    }
}
