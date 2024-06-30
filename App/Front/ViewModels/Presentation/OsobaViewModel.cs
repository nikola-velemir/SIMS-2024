using App.Back.Domain;
using System.ComponentModel;
using System.Reflection;

public class OsobaViewModel : INotifyPropertyChanged, IDataErrorInfo
{
    private int _id;
    private string _ime;
    private string _prezime;
    private string _jmbg;
    private DateTime _datumRodjenja;
    private Polovi _pol;
    private int? _idNaloga;
    private string _error;
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

    public string Ime
    {
        get => _ime;
        set
        {
            if (_ime != value)
            {
                _ime = value;
                OnPropertyChanged(nameof(Ime));
            }
        }
    }

    public string Prezime
    {
        get => _prezime;
        set
        {
            if (_prezime != value)
            {
                _prezime = value;
                OnPropertyChanged(nameof(Prezime));
            }
        }
    }

    public string JMBG
    {
        get => _jmbg;
        set
        {
            if (_jmbg != value)
            {
                _jmbg = value;
                OnPropertyChanged(nameof(JMBG));
            }
        }
    }

    public DateTime DatumRodjenja
    {
        get => _datumRodjenja;
        set
        {
            if (_datumRodjenja != value)
            {
                _datumRodjenja = value;
                OnPropertyChanged(nameof(DatumRodjenja));
            }
        }
    }

    public Polovi Pol
    {
        get => _pol;
        set
        {
            if (_pol != value)
            {
                _pol = value;
                OnPropertyChanged(nameof(Pol));
            }
        }
    }

    public int? IdNaloga
    {
        get => _idNaloga;
        set
        {
            if (_idNaloga != value)
            {
                _idNaloga = value;
                OnPropertyChanged(nameof(IdNaloga));
            }
        }
    }

    public bool IsValid
    {
        get
        {
            // Get all public properties of the class
            PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            // Iterate through the properties and check for validation errors
            foreach (PropertyInfo property in properties)
            {
                string error = this[property.Name];
                if (!string.IsNullOrEmpty(error))
                {
                    Error = error;
                    return false;
                }
            }
            Error = string.Empty;
            return true;
        }
    }

    public OsobaViewModel()
    {
        Ime = string.Empty;
        Prezime = string.Empty;
        JMBG = string.Empty;
    }

    public OsobaViewModel(int id, string ime, string prezime, string jmbg, DateOnly datumRodjenja, Polovi pol)
    {
        Id = id;
        Ime = ime;
        Prezime = prezime;
        JMBG = jmbg;
        DatumRodjenja = datumRodjenja.ToDateTime(new TimeOnly(0, 0));
        Pol = pol;
        IdNaloga = null;
    }

    public OsobaViewModel(int id, string ime, string prezime, string jmbg, DateOnly datumRodjenja, Polovi pol, int idNaloga)
    {
        Id = id;
        Ime = ime;
        Prezime = prezime;
        JMBG = jmbg;
        DatumRodjenja = datumRodjenja.ToDateTime(new TimeOnly(0, 0));
        Pol = pol;
        IdNaloga = idNaloga;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // IDataErrorInfo implementation
    public string Error
    {
        get { return _error; }
        set
        {
            if (value != _error)
            {
                _error = value;
                OnPropertyChanged(nameof(Error));
            }
        }
    }

    public string this[string columnName]
    {
        get
        {
            string result = "";
            switch (columnName)
            {
                case nameof(Ime):
                    if (string.IsNullOrWhiteSpace(Ime)) { }
                    result = "First name cannot be empty.";
                    break;
                case nameof(Prezime):
                    if (string.IsNullOrWhiteSpace(Prezime))
                        result = "Last name cannot be empty.";
                    break;
                case nameof(JMBG):
                    if (string.IsNullOrWhiteSpace(JMBG))
                        result = "JMBG cannot be empty.";
                    break;
                case nameof(DatumRodjenja):
                    if (DatumRodjenja == default(DateTime))
                        result = "Birth date must be set.";
                    if (DatumRodjenja.CompareTo(DateTime.Now) >= 0)
                        result = "Birth date cannot be in the future.";
                    break;
                case nameof(Pol):
                    if (!Enum.IsDefined(typeof(Polovi), Pol))
                        result = "Gender is not valid.";
                    break;
                default:
                    result = "";
                    break;
            }
            return result;
        }
    }
}
