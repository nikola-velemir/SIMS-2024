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
using App.Back.Domain;
using App.Front.Views;
using System.Windows;

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
        private object _selectedItem;
        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
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

        private ICommand _addMusicItemCommand;
        public ICommand AddMusicItemCommand 
        {
            get { return _addMusicItemCommand; }
            set
            {
                if(value != null)
                {
                    _addMusicItemCommand = value;
                    OnPropertyChanged(nameof(AddMusicItemCommand));
                }
            }
        }
        private ICommand _deleteMusicItemCommand;
        public ICommand DeleteMusicItemCommand 
        {
            get { return _deleteMusicItemCommand; }
            set
            {
                if(value != null)
                {
                    _deleteMusicItemCommand = value;
                    OnPropertyChanged(nameof(DeleteMusicItemCommand));
                }
            }
        }

        private ICommand _updateMusicItemCommand;
        public ICommand UpdateMusicItemCommand
        {
            get { return _updateMusicItemCommand; }
            set
            {
                if(value != null)
                {
                    _updateMusicItemCommand = value;
                    OnPropertyChanged(nameof(UpdateMusicItemCommand));
                }
            }
        }

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
                CurrentItems.Add(genre);
            }
            AddMusicItemCommand = new RelayCommand(i => AddMusicGenre());
            DeleteMusicItemCommand = new RelayCommand(d => DeleteMusicGenre((MusicalGenreDTO)SelectedItem));
            UpdateMusicItemCommand = new RelayCommand(u => UpdateMusicGenre((MusicalGenreDTO)SelectedItem));
        }
        private void ShowMusicPiece()
        {
            var musicalPieces = _pieceService.GetAll();
            CurrentItems.Clear();
            foreach (var musicalPiece in musicalPieces)
            {
                CurrentItems.Add(musicalPiece);
            }
            AddMusicItemCommand = new RelayCommand(o => AddMusicPiece());
            DeleteMusicItemCommand = new RelayCommand(d => DeleteMusicPiece((MusicPieceDTO)SelectedItem));
        }
        private void AddMusicPiece()
        {
            MusicalPieceView musicalPieceView = new MusicalPieceView();
            musicalPieceView.Closed += CreateMusicPieceView_Closed;
            musicalPieceView.Show();
        }
        private void CreateMusicPieceView_Closed(object? sender, EventArgs e)
        {
            ShowMusicPiece();
        }

        private void AddMusicGenre()
        {
            CreateMusicGenreView createMusicGenreView = new CreateMusicGenreView(null);
            createMusicGenreView.Closed += CreateMusicGenreView_Closed;
            createMusicGenreView.Show();
        }
        private void CreateMusicGenreView_Closed(object? sender, EventArgs e)
        {
            ShowMusicGenre();
        }
        private void AddMusicEditor()
        {
            
        }

        private void UpdateMusicGenre(MusicalGenreDTO musicalGenreDTO)
        {
            if(musicalGenreDTO != null)
            {
                CreateMusicGenreView createMusicGenreView = new CreateMusicGenreView(musicalGenreDTO);
                createMusicGenreView.Closed += CreateMusicGenreView_Closed;
                createMusicGenreView.Show();
            }

        }

        private void DeleteMusicPiece(MusicPieceDTO musicPieceDTO)
        {
            if(musicPieceDTO != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete selected music piece?", "Delete", MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        _pieceService.Delete(musicPieceDTO);
                        ShowMusicPiece();
                        MessageBox.Show("You successfuly delete music piece");
                        break;
                    default:
                        break;
                }
                
            }
            
            
        }

        private void DeleteMusicGenre(MusicalGenreDTO musicalGenreDTO)
        {
            if(musicalGenreDTO != null)
            {

                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete selected music genre?", "Delete", MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        _genreService.Delete(musicalGenreDTO);
                        ShowMusicGenre();
                        MessageBox.Show("You successfuly delete music genre");
                        break;
                    default:
                        break;
                }
            }
        }
        private void DeleteMusicEditor()
        {

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
