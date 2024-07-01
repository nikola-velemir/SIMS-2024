using App.Back.Service;
using App.Front.ViewModels.Presentation;
using App.Front.ViewModels.Presentation.Wrappers;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace App.Front.Views
{
    public class EditPlayListViewViewModel
    {
        private MusicalPieceService _musicalPieceService;
        public UserAccountViewModel Account { get; set; }
        public ObservableCollection<MusicalPieceWrapperViewModel> Pieces { get; set; }
        public ObservableCollection<MusicalPieceWrapperViewModel> AddedPieces { get; set; }
        public PlayListViewModel PlayList { get; set; }
        public EditPlayListViewViewModel(UserAccountViewModel account, PlayListViewModel playList)
        {
            Account = account;
            PlayList = playList;
            _musicalPieceService = new();
            Pieces = new();
            AddedPieces = new();
            FillAddedPieces();
            Update();
        }
        private void FillAddedPieces()
        {
            foreach (var id in PlayList.Pieces)
            {
                var piece = _musicalPieceService.GetById(id);
                if (piece == null) { continue; }

                AddedPieces.Add(new MusicalPieceWrapperViewModel(new MusicalPieceViewModel(piece)));
            }
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

        public void AddPieces(MusicalPieceWrapperViewModel piece)
        {
            AddedPieces.Add(piece);
            Update();
        }

        internal void RemovePiece(MusicalPieceWrapperViewModel piece)
        {
            AddedPieces.Remove(piece);
            Update();
        }
    }
}