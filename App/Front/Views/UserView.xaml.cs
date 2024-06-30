using System.Windows;

namespace App.Front.Views
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : Window
    {
        public UserView()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
