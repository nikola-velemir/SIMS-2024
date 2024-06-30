using App.Back.Domain;
using System.ComponentModel;
using System.Reflection;

public class PersonViewModel : INotifyPropertyChanged, IDataErrorInfo
{
    private int _id;
    private string _firstName;
    private string _lastName;
    private string _jmbg;
    private DateTime _birthDate;
    private Genders _gender;
    private int? _accountId;
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

    public string FirstName
    {
        get => _firstName;
        set
        {
            if (_firstName != value)
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (_lastName != value)
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
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

    public DateTime BirthDate
    {
        get => _birthDate;
        set
        {
            if (_birthDate != value)
            {
                _birthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }
    }

    public Genders Gender
    {
        get => _gender;
        set
        {
            if (_gender != value)
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }
    }

    public int? AccountId
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

    public PersonViewModel()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        JMBG = string.Empty;
    }

    public PersonViewModel(int id, string firstName, string lastName, string jmbg, DateOnly datumRodjenja, Genders pol)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        JMBG = jmbg;
        BirthDate = datumRodjenja.ToDateTime(new TimeOnly(0, 0));
        Gender = pol;
        AccountId = null;
    }

    public PersonViewModel(int id, string firstName, string lastName, string jmbg, DateOnly datumRodjenja, Genders pol, int idNaloga)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        JMBG = jmbg;
        BirthDate = datumRodjenja.ToDateTime(new TimeOnly(0, 0));
        Gender = pol;
        AccountId = idNaloga;
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
                case nameof(FirstName):
                    if (string.IsNullOrWhiteSpace(FirstName))
                        result = "First name cannot be empty.";
                    break;
                case nameof(LastName):
                    if (string.IsNullOrWhiteSpace(LastName))
                        result = "Last name cannot be empty.";
                    break;
                case nameof(JMBG):
                    if (string.IsNullOrWhiteSpace(JMBG))
                        result = "JMBG cannot be empty.";
                    break;
                case nameof(BirthDate):
                    if (BirthDate == default)
                        result = "Birth date must be set.";
                    if (BirthDate.CompareTo(DateTime.Now) >= 0)
                        result = "Birth date cannot be in the future.";
                    break;
                case nameof(Gender):
                    if (!Enum.IsDefined(typeof(Genders), Gender))
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
