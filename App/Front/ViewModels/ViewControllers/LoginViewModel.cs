using App.Back.Domain;
using App.Back.Service;
using System.ComponentModel;

namespace App.Front.ViewModels.ViewControllers
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private NalogService _nalogService;

        private string _error;

        public event PropertyChangedEventHandler? PropertyChanged;

        public NalogViewModel Nalog { get; set; }
        public LoginViewModel()
        {
            Nalog = new NalogViewModel();
            _nalogService = new NalogService();
            _error = "";
        }
        public Nalog? Login()
        {
            if (!IsValid()) { return null; }

            var found = _nalogService.GeyByKorisnickoAndLozinka(Nalog.KorisnickoIme, Nalog.Lozinka);
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
            if (string.IsNullOrEmpty(Nalog.KorisnickoIme))
            {
                Error = "Username is requeired!";
                return false;
            }
            if (string.IsNullOrEmpty(Nalog.Lozinka))
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

    }
}
