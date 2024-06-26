using App.Back.Service;

namespace App.Front.ViewModels.ViewControllers
{
    public class LoginViewModel
    {
        private NalogService _nalogService;
        public NalogViewModel Nalog { get; set; }
        public LoginViewModel()
        {
            Nalog = new NalogViewModel();
            _nalogService = new NalogService();
        }
        public int Login()
        {
            var found = _nalogService.GeyByKorisnickoAndLozinka(Nalog.KorisnickoIme, Nalog.Lozinka);
            if (found == null) { return -1; }
            return found.Id;
        }
    }
}
