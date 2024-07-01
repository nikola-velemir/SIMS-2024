using App.Back.Domain;
using System.ComponentModel;

namespace App.Front.ViewModels.Presentation
{
    public class MusicalGenreViewModel : INotifyPropertyChanged, IDataErrorInfo
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

        public string Error => throw new NotImplementedException();

        public string this[string columnName] => throw new NotImplementedException();

        public MusicalGenreViewModel() { }

        public MusicalGenreViewModel(MusicGenre musicalGenre)
        {
            _id = musicalGenre.Id;
            _name = musicalGenre.Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
