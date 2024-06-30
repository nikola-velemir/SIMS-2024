using App.Back.Service;
using App.Front.ViewModels.Presentation.Wrappers;
using System.Collections.ObjectModel;

namespace App.Front.ViewModels.ViewControllers
{
    public class UserViewViewModel
    {
        private MusicalNotionService _notionService;

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
            foreach (var instance in instances) {
                Notions.Add(new MusicalNotionWrapperViewModel(new MusicalNotionViewModel(instance)));
            }
        }
    }
}
