using App.Back.Service;
using App.Front.ViewModels.Presentation;

namespace App.Front.ViewModels.ViewControllers
{
    public class CreatePlayListViewModel
    {
        private PlayListService _playListService;
        public UserAccountViewModel Account { get; set; }
        public PlayListViewModel PlayList { get; set; }
        public CreatePlayListViewModel(UserAccountViewModel account)
        {
            _playListService = new();
            Account = account;
            PlayList = new PlayListViewModel();
        }
        public bool Create()
        {
            PlayList.Pieces = new List<int>();
            PlayList.AccountId = Account.Id;
            PlayList.DateCreated = DateOnly.FromDateTime(DateTime.Now);
            var pl = _playListService.Create(PlayList.ToPlayList());
            return pl != null;
        }
    }
}
