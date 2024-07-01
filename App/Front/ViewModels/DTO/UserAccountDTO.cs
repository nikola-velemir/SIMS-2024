using App.Back.Domain;
using System.ComponentModel;
using System.Reflection;

public class UserAccountDTO : INotifyPropertyChanged, IDataErrorInfo
{
    public int Id;
    private string _password;
    private string _username;
    public bool Active;
    public AccountType AccountType;
    public int PersonId;



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

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }


    private readonly string[] _validatedProperties = { "Password", "UserName"};
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

    public string Error => null;

    public string this[string columnName]
    {
        get
        {
            if (columnName == "Password")
            {
                if (string.IsNullOrEmpty(Password))
                {
                    return "Password is required";
                }
                if(Password.Length < 5)
                {
                    return "Password must have 5 characters";
                }
            }
            else if (columnName == "UserName")
            {
                if (string.IsNullOrEmpty(UserName))
                {
                    return "Username is required";
                }
                if (UserName.Length < 5)
                {
                    return "UserName must have 5 characters";
                }
            }
            return null;
        }
        
    }

    public UserAccount ToUserAccount()
    {
        return new UserAccount(Id, Password, UserName, Active, AccountType, PersonId);
    }

    public UserAccountDTO()
    {
       
    }

    public UserAccountDTO(int id, string password, string userName, bool active, AccountType accountType, int personid)
    {
        Id = id;
        Password = password;
        UserName = userName;
        Active = active;
        AccountType = accountType;
        PersonId = personid;
    }

    public UserAccountDTO(UserAccount other)
    {
        Id = other.Id;
        AccountType = other.Type;
        Password = other.Password;
        Active = other.Active;
        UserName = other.UserName;
        PersonId = other.PersonId;
    }


}
