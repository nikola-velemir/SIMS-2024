using App.Back.Service;
using App.Front.ViewModels.Presentation;
using App.Front.ViewModels.Presentation.Wrappers;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace App.Front.Views
{
    public class CreatePlayListViewViewModel
    {
        private MusicalPieceService _musicalPieceService;
        public UserAccountViewModel Account { get; set; }
        public ObservableCollection<MusicalPieceWrapperViewModel> Pieces { get; set; }
        public ObservableCollection<MusicalPieceWrapperViewModel> AddedPieces { get; set; }
        public CreatePlayListViewViewModel(UserAccountViewModel account)
        {
            Account = account;
            _musicalPieceService = new();
            Pieces = new();
            AddedPieces = new();
            Update();
        }
        private bool ExistsInAddedPieces(MusicalPieceWrapperViewModel vm)
        {
            foreach (var pvm in AddedPieces)
            {
                if (pvm.Piece.Id == vm.Piece.Id)
                {
                    return true;
                }
            }
            return false;
        }
        public void Update()
        {
            Pieces.Clear();
            foreach (var p in _musicalPieceService.GetAll())
            {
                var vm = new MusicalPieceWrapperViewModel(new MusicalPieceViewModel(p));
                if (!ExistsInAddedPieces(vm)) { Pieces.Add(vm); }
            }

        }
    }
}