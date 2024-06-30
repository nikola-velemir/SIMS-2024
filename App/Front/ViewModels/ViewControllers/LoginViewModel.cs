using App.Back.Domain;
using App.Back.Service;
using App.Front.Views;
using System.ComponentModel;
using System.Windows;

namespace App.Front.ViewModels.ViewControllers
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private UserAccountService _accountService;

        private string _error;

        public event PropertyChangedEventHandler? PropertyChanged;

        public UserAccountViewModel Account { get; set; }
        public LoginViewModel()
        {
            Account = new UserAccountViewModel();
            _accountService = new UserAccountService();
            _error = "";
        }
        public UserAccount? Login()
        {
            if (!IsValid()) { return null; }

            var found = _accountService.GeyByKorisnickoAndLozinka(Account.UserName, Account.Password);
            if (found == null)
            {
                Error = "Username or password are incorrect!";
            }

            return found;
        }
        public string Error
        {
            get { return _error; }
            set
            {
                if (_error != value)
                {
                    _error = value;
                    OnPropertyChanged(nameof(Error));
                }
            }
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Account.UserName))
            {
                Error = "Username is requeired!";
                return false;
            }
            if (string.IsNullOrEmpty(Account.Password))
            {
                Error = "Password is requeired!";
                return false;
            }
            Error = "";
            return true;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool LogIn(string password)
        {
            Account.Password = password;
            var nalog = Login();
            if (nalog != null)
            {
                MessageBox.Show("Welcome " + Account.UserName + "!");
                var window = new UserView(new UserAccountViewModel(nalog));
                window.Show();
                return true;
            }
            return false;
        }

    }
}
