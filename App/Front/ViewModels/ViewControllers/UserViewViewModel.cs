using App.Back.Service;
using App.Front.ViewModels.Presentation.Wrappers;
using System.Collections.ObjectModel;

namespace App.Front.ViewModels.ViewControllers
{
    public class UserViewViewModel
    {
        private MusicalNotionService _notionService;
        public ObservableCollection<MusicalNotionWrapperViewModel> Notions { get; set; }

        public UserViewViewModel()
        {
            Notions = new();
            Fill();
        }

        public void Fill()
        {
            var instances = _notionService.GetAll();
            foreach (var instance in instances) {
                Notions.Add(new MusicalNotionWrapperViewModel(new MusicalNotionViewModel(instance)));
            }
        }
    }
}
