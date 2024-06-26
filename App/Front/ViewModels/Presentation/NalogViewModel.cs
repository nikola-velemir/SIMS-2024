using App.Back.Domain;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class NalogViewModel : INotifyPropertyChanged
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
