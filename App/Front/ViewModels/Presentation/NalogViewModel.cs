using App.Back.Domain;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

public class NalogViewModel : INotifyPropertyChanged, IDataErrorInfo
{
    private int id;
    private string lozinka;
    private string korisnickoIme;
    private bool aktivan;
    private TipNaloga tip;
    private int idOsobe;

    public int Id
    {
        get => id;
        set
        {
            if (id != value)
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
    }

    public string Lozinka
    {
        get => lozinka;
        set
        {
            if (lozinka != value)
            {
                lozinka = value;
                OnPropertyChanged(nameof(Lozinka));
            }
        }
    }

    public string KorisnickoIme
    {
        get => korisnickoIme;
        set
        {
            if (korisnickoIme != value)
            {
                korisnickoIme = value;
                OnPropertyChanged(nameof(KorisnickoIme));
            }
        }
    }

    public bool Aktivan
    {
        get => aktivan;
        set
        {
            if (aktivan != value)
            {
                aktivan = value;
                OnPropertyChanged(nameof(Aktivan));
            }
        }
    }

    public TipNaloga Tip
    {
        get => tip;
        set
        {
            if (tip != value)
            {
                tip = value;
                OnPropertyChanged(nameof(Tip));
            }
        }
    }

    public int IdOsobe
    {
        get => idOsobe;
        set
        {
            if (idOsobe != value)
            {
                idOsobe = value;
                OnPropertyChanged(nameof(IdOsobe));
            }
        }
    }

    public NalogViewModel()
    {
        Lozinka = string.Empty;
        KorisnickoIme = string.Empty;
    }

    public NalogViewModel(int id, string lozinka, string korisnickoIme, bool aktivan, TipNaloga tip, int idOsobe)
    {
        Id = id;
        Lozinka = lozinka;
        KorisnickoIme = korisnickoIme;
        Aktivan = aktivan;
        Tip = tip;
        IdOsobe = idOsobe;
    }

    public NalogViewModel(NalogViewModel other)
    {
        Id = other.Id;
        Tip = other.Tip;
        Lozinka = other.Lozinka;
        Aktivan = other.Aktivan;
        KorisnickoIme = other.KorisnickoIme;
        IdOsobe = other.IdOsobe;
    }

    public Nalog ToNalog()
    {
        return new Nalog(Id, Lozinka, KorisnickoIme, Aktivan, Tip, IdOsobe);
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
                case nameof(Lozinka):
                    if (string.IsNullOrWhiteSpace(Lozinka))
                        result = "Lozinka cannot be empty.";
                    break;
                case nameof(KorisnickoIme):
                    if (string.IsNullOrWhiteSpace(KorisnickoIme))
                        result = "KorisnickoIme cannot be empty.";
                    break;
                case nameof(Aktivan):
                    // No validation needed for bool type
                    break;
                case nameof(Tip):
                    if (!Enum.IsDefined(typeof(TipNaloga), Tip))
                        result = "Type is not valid.";
                    break;
                case nameof(IdOsobe):
                    if (IdOsobe <= 0)
                        result = "IdOsobe must be a positive number.";
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
