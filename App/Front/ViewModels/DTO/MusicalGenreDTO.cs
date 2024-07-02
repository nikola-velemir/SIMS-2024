using App.Back.Domain;
using System.ComponentModel;

namespace App.Front.ViewModels.DTO
{
    public class MusicalGenreDTO : INotifyPropertyChanged, IDataErrorInfo
    {
        private int _id;
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

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if(columnName == "Name")
                {
                    if(string.IsNullOrEmpty(Name))
                    {
                        return "Genre must have a name";
                    }
                }
                return null;
            }
        }

        private readonly string[] _validatedProperties = { "Name" };
        public bool IsValid
        {
            get
            {
                foreach (var property in _validatedProperties)
                {
                    if (this[property] != null)
                        return false;
                }

                return true;
            }
        }
        public MusicalGenreDTO() { }

        public MusicalGenreDTO(MusicGenre musicalGenre)
        {
            _id = musicalGenre.Id;
            _name = musicalGenre.Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public MusicGenre ToMusicGenre()
        {
            return new MusicGenre(Id, Name);
        }
    }
}
