using App.Back.Domain;
using System.ComponentModel;
using System.Reflection;

public class UserAccountViewModel : INotifyPropertyChanged, IDataErrorInfo
{
    private int _id;
    private string _password;
    private string _username;
    private bool _active;
    private AccountType _type;
    private int _personId;

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

    public string Password
    {
        get => _password;
        set
        {
            if (_password != value)
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
    }

    public string UserName
    {
        get => _username;
        set
        {
            if (_username != value)
            {
                _username = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
    }

    public bool Active
    {
        get => _active;
        set
        {
            if (_active != value)
            {
                _active = value;
                OnPropertyChanged(nameof(Active));
            }
        }
    }

    public AccountType Type
    {
        get => _type;
        set
        {
            if (_type != value)
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
    }

    public int PersonId
    {
        get => _personId;
        set
        {
            if (_personId != value)
            {
                _personId = value;
                OnPropertyChanged(nameof(PersonId));
            }
        }
    }

    public UserAccountViewModel()
    {
        Password = string.Empty;
        UserName = string.Empty;
    }

    public UserAccountViewModel(int id, string lozinka, string korisnickoIme, bool aktivan, AccountType tip, int idOsobe)
    {
        Id = id;
        Password = lozinka;
        UserName = korisnickoIme;
        Active = aktivan;
        Type = tip;
        PersonId = idOsobe;
    }

    public UserAccountViewModel(UserAccountViewModel other)
    {
        Id = other.Id;
        Type = other.Type;
        Password = other.Password;
        Active = other.Active;
        UserName = other.UserName;
        PersonId = other.PersonId;
    }

    public UserAccount ToUserAccount()
    {
        return new UserAccount(Id, Password, UserName, Active, Type, PersonId);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // IDataErrorInfo implementation
    public string Error { get; set; }

    public string this[string columnName]
    {
        get
        {
            string result = "";
            switch (columnName)
            {
                case nameof(Id):
                    if (Id <= 0)
                        result = "Id must be a positive number.";
                    break;
                case nameof(Password):
                    if (string.IsNullOrWhiteSpace(Password))
                        result = "Lozinka cannot be empty.";
                    break;
                case nameof(UserName):
                    if (string.IsNullOrWhiteSpace(UserName))
                        result = "KorisnickoIme cannot be empty.";
                    break;
                case nameof(Active):
                    // No validation needed for bool type
                    break;
                case nameof(Type):
                    if (!Enum.IsDefined(typeof(AccountType), Type))
                        result = "Type is not valid.";
                    break;
               
                default:
                    break;
            }
            return result;
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
                    return false;
                }
            }
            return true;
        }
    }
}
