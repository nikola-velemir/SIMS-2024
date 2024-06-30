using App.Back.Domain;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class MusicalGenreViewModel : INotifyPropertyChanged
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

    public MusicalGenreViewModel() { }

    public MusicalGenreViewModel(int id, string name)
    {
        _id = id;
        _name = name;
    }

    public MusicalGenreViewModel(MusicalGenre musicalGenre)
    {
        this._id = musicalGenre.Id;
        this._name = musicalGenre.Name;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
