using App.Back.Service;
using App.Front.ViewModels.DTO;
using App.Front.ViewModels.Presentation.Wrappers;
using App.Front.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App.Front.ViewModels.Presentation
{
    public class AdminCrudViewModel: INotifyPropertyChanged
    {
        private MusicalPieceService _pieceService;
        private MusicalGenreService _genreService;
        private PersonService _personService;
        private UserAccountService _userAccountService;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand AddMusicPieceCommand { get; }
        public ICommand AddMusicGenreCommand { get; }
        public ICommand AddMusicEditorCommand { get; }

        private void AddMusicPiece()
        {
            MusicalPieceView musicalPieceView = new MusicalPieceView();
            musicalPieceView.Show();
        }

        public AdminCrudViewModel()
        {
            AddMusicPieceCommand = new RelayCommand(o => AddMusicPiece());
            _genreService = new MusicalGenreService();
            _pieceService = new MusicalPieceService();
            _personService = new PersonService();
            _userAccountService = new UserAccountService();
        }
    }
}
