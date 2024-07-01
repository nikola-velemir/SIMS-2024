using App.Back.Service;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using App.Front.ViewModels.DTO;
using App.Front.ViewModels.Presentation.Wrappers;

namespace App.Front.ViewModels.Presentation
{
    public class AdminItemViewModel: INotifyPropertyChanged
    {
        private MusicalPieceService _pieceService;
        private MusicalGenreService _genreService;
        private PersonService _personService;
        private UserAccountService _userAccountService;

        private ObservableCollection<object> _currentItems;
        public ObservableCollection<object> CurrentItems
        {
            get { return _currentItems; }
            set
            {
                _currentItems = value;
                OnPropertyChanged(nameof(CurrentItems));
                
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand ShowMusicEditorCommand { get; }
        public ICommand ShowMusicGenreCommand { get; }
        public ICommand ShowMusicPieceCommand { get; }

        private void ShowMusicEditor()
        {
            var editorAccounts = _userAccountService.GetAllEditors();
            CurrentItems.Clear();
            foreach (var account in editorAccounts)
            {
                var person = _personService.GetByAccountId(account.Id);
                var currentEditor = new EditorViewModel(new PersonDTO(person), new UserAccountDTO(account));
                CurrentItems.Add(currentEditor);
            }
        }

        private void ShowMusicGenre()
        {
            var genres = _genreService.GetAll();
            CurrentItems.Clear();
            foreach(var genre in genres)
            {
                CurrentItems.Add(new MusicalGenreViewModel(genre));
            }
        }
        private void ShowMusicPiece()
        {
            var musicalPieces = _pieceService.GetAll();
            CurrentItems.Clear();
            foreach (var musicalPiece in musicalPieces)
            {
                CurrentItems.Add(new MusicalNotionWrapperViewModel(new MusicalNotionViewModel(musicalPiece)));
            }
        }

        public AdminItemViewModel()
        {
            ShowMusicEditorCommand = new RelayCommand(o => ShowMusicEditor());
            ShowMusicGenreCommand = new RelayCommand(o => ShowMusicGenre());
            ShowMusicPieceCommand = new RelayCommand(o => ShowMusicPiece());
            _genreService = new MusicalGenreService();
            _pieceService = new MusicalPieceService();
            _personService = new PersonService();
            _userAccountService = new UserAccountService();
            CurrentItems = new ObservableCollection<object>();
        }


    }
}
