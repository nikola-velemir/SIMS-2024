using App.Back.Service;
using App.Front.ViewModels.Presentation;

namespace App.Front.ViewModels.ViewControllers
{
    public class CreatePlayListViewModel
    {
        private PlayListService _playListService;
        public UserAccountDTO Account { get; set; }
        public PlayListViewModel PlayList { get; set; }
        public CreatePlayListViewModel(UserAccountDTO account)
        {
            _playListService = new();
            Account = account;
            PlayList = new PlayListViewModel();
        }
        public bool Create()
        {
            if (string.IsNullOrEmpty(PlayList.Name)) { return false; }  
            PlayList.Pieces = new List<int>();
            PlayList.AccountId = Account.Id;
            PlayList.DateCreated = DateOnly.FromDateTime(DateTime.Now);
            var pl = _playListService.Create(PlayList.ToPlayList());
            return pl != null;
        }
    }
}
