using App.Back.Domain;
using App.Back.Repository;
using App.Back.Service;
using App.Front.ViewModels.Presentation;
using System.Collections.ObjectModel;

namespace App.Front.ViewModels.ViewControllers
{
    public class UserLibraryViewModel
    {
        private PlayListService _playListService;
        public ObservableCollection<PlayListViewModel> PlayLists { get; set; }
        public UserAccountDTO Account { get; set; }
        public UserLibraryViewModel(UserAccountDTO account)
        {
            PlayLists = new();
            Account = account;
            _playListService = new PlayListService();
            Fill();
        }

        public void Fill()
        {
            PlayLists.Clear();
            var userPlayLists = _playListService.GetByUserId(Account.Id);
            foreach (var list in userPlayLists)
            {
                PlayLists.Add(new PlayListViewModel(list));
            }

        }

    }
}
