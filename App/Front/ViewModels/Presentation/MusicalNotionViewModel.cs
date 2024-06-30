using App.Back.Domain;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class MusicalNotionViewModel : INotifyPropertyChanged
{
    private int _id;
    private string _description;
    private int _musicalGenreId;
    private int _profileImageId;

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

    public string Description
    {
        get => _description;
        set
        {
            if (_description != value)
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
    }

    public int MusicalGenreId
    {
        get => _musicalGenreId;
        set
        {
            if (_musicalGenreId != value)
            {
                _musicalGenreId = value;
                OnPropertyChanged(nameof(MusicalGenreId));
            }
        }
    }

    public int ProfileImageId
    {
        get => _profileImageId;
        set
        {
            if (_profileImageId != value)
            {
                _profileImageId = value;
                OnPropertyChanged(nameof(ProfileImageId));
            }
        }
    }

    public MusicalNotionViewModel() { }

    public MusicalNotionViewModel(int id, string description, int musicalGenreId, int profileImageId)
    {
        _id = id;
        _description = description;
        _musicalGenreId = musicalGenreId;
        _profileImageId = profileImageId;
    }

    public MusicalNotionViewModel(MusicalNotionViewModel other)
    {
        _id = other.Id;
        _description = other.Description;
        _musicalGenreId = other.MusicalGenreId;
        _profileImageId = other.ProfileImageId;
    }
    public MusicalNotionViewModel(MusicalNotion other)
    {
        _id = other.Id;
        _description = other.Description;
        _musicalGenreId = other.MusicalGenreId;
        _profileImageId = other.ProfileImageId;
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
