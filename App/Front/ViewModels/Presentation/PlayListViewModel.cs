using App.Back.Domain;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace App.Front.ViewModels.Presentation
{
    public class PlayListViewModel : INotifyPropertyChanged
    {
        private int _id;
        private int _accountId;
        private List<int> _pieces;
        private string _name;

        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public int AccountId
        {
            get => _accountId;
            set
            {
                if (_accountId != value)
                {
                    _accountId = value;
                    OnPropertyChanged(nameof(AccountId));
                }
            }
        }

        public List<int> Pieces
        {
            get => _pieces;
            set
            {
                if (_pieces != value)
                {
                    _pieces = value;
                    OnPropertyChanged(nameof(Pieces));
                }
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public PlayListViewModel()
        {
            _pieces = new List<int>();
        }

        public PlayListViewModel(int id, int accountId, string name, List<int> pieces)
        {
            _id = id;
            _accountId = accountId;
            _pieces = pieces;
            _name = name;
        }

        public PlayListViewModel(int id, UserAccount user, string name, List<MusicalPiece> pieces)
        {
            _id = id;
            _accountId = user.Id;
            _pieces = new List<int>();
            FillPesme(pieces);
            _name = name;
        }

        public PlayListViewModel(PlayList other)
        {
            _id = other.Id;
            _accountId = other.AccountId;
            _pieces = new List<int>(other.Pieces);
            _name = other.Name;
        }

        private void FillPesme(List<MusicalPiece> pieces)
        {
            foreach (MusicalPiece md in pieces)
            {
                if (!_pieces.Contains(md.Id))
                    _pieces.Add(md.Id);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
