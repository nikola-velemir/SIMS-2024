using App.Front.ViewModels.Presentation;
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
    /// Interaction logic for AdministratorView.xaml
    /// </summary>
    public partial class AdministratorView : Window
    {
        public AdminItemViewModel CurrentAdminItems { get; set; }
        public AdministratorView()
        {
            InitializeComponent();
            DataContext = this;
            CurrentAdminItems = new AdminItemViewModel();
        }
    }
}
