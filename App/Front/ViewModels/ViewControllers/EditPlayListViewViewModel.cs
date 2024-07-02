using App.Back.Service;
using App.Front.ViewModels.Presentation.Wrappers;
using App.Front.ViewModels.Presentation;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

public class EditPlayListViewViewModel : INotifyPropertyChanged
{
    private MusicalPieceService _musicalPieceService;
    private PlayListService _playListService;

    public UserAccountDTO Account { get; set; }
    public ObservableCollection<MusicalPieceWrapperViewModel> Pieces { get; set; }
    public ObservableCollection<MusicalPieceWrapperViewModel> AddedPieces { get; set; }
    public PlayListViewModel PlayList { get; set; }

    private string _searchQuery;
    public string SearchQuery
    {
        get => _searchQuery;
        set
        {
            if (_searchQuery != value)
            {
                _searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));
                PerformSearch();
            }
        }
    }

    public EditPlayListViewViewModel(UserAccountDTO  account, PlayListViewModel playList)
    {
        Account = account;
        PlayList = playList;
        _musicalPieceService = new MusicalPieceService();
        _playListService = new PlayListService();
        Pieces = new ObservableCollection<MusicalPieceWrapperViewModel>();
        AddedPieces = new ObservableCollection<MusicalPieceWrapperViewModel>();
        _searchQuery = string.Empty;
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

       // PerformSearch();
    }

    private void PerformSearch()
    {
        Pieces.Clear();
        if (string.IsNullOrWhiteSpace(SearchQuery))
        {
            Update();
        }
        else
        {
            var filteredPieces = _musicalPieceService.GetAll()
                .Where(p => p.Description.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
                .Select(p => new MusicalPieceWrapperViewModel(new MusicalPieceViewModel(p)))
                .ToList();

            Pieces.Clear();
            foreach (var vm in filteredPieces)
            {
                if (!ExistsInAddedPieces(vm))
                {
                    Pieces.Add(vm);
                }
            }
        }
    }

    public void AddPiece(MusicalPieceWrapperViewModel piece)
    {
        AddedPieces.Add(piece);
        PerformSearch();
    }

    public void RemovePiece(MusicalPieceWrapperViewModel piece)
    {
        AddedPieces.Remove(piece);
        PerformSearch();
    }

    public bool Save()
    {
        if (!PlayList.IsValid) { return false; }
        PlayList.Pieces = new List<int>();
        foreach (var ap in AddedPieces)
        {
            PlayList.Pieces.Add(ap.Piece.Id);
        }
        var a = _playListService.Update(PlayList.ToPlayList());
        return a != null;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
