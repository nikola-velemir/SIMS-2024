using App.Back.Domain;
using App.Back.Service;
using App.Front.ViewModels.Presentation.Wrappers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace App.Front.ViewModels.ViewControllers
{
    public class UserViewViewModel : INotifyPropertyChanged
    {
        private MusicalNotionService _notionService;
        private string _searchText;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                    FilterNotions();
                }
            }
        }
        public UserAccountViewModel Account { get; set; }
        public ObservableCollection<MusicalNotionWrapperViewModel> Notions { get; set; }

        public UserViewViewModel(UserAccountViewModel account)
        {
            Notions = new();
            _notionService = new MusicalNotionService();
            Account = account;
            Fill();
        }

        public void Fill()
        {
            Notions.Clear();
            var instances = _notionService.GetAll();
            foreach (var instance in instances)
            {
                Notions.Add(new MusicalNotionWrapperViewModel(new MusicalNotionViewModel(instance)));
            }
        }
        private void FilterNotions(IEnumerable<MusicalNotion> instances = null)
        {
            if (instances == null)
            {
                instances = _notionService.GetAll();
            }

            var filteredInstances = string.IsNullOrEmpty(SearchText)
                ? instances
                : instances.Where(n => n.Description.Contains(SearchText, StringComparison.OrdinalIgnoreCase));

            Notions.Clear();
            foreach (var instance in filteredInstances)
            {
                Notions.Add(new MusicalNotionWrapperViewModel(new MusicalNotionViewModel(instance)));
            }
        }


        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
