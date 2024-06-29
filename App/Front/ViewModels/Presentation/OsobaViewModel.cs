using App.Back.Domain;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class OsobaViewModel : INotifyPropertyChanged
{
    private int id;
    private string ime;
    private string prezime;
    private string jmbg;
    private DateTime datumRodjenja;
    private Polovi pol;
    private int? idNaloga;

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

    public string Ime
    {
        get => ime;
        set
        {
            if (ime != value)
            {
                ime = value;
                OnPropertyChanged();
            }
        }
    }

    public string Prezime
    {
        get => prezime;
        set
        {
            if (prezime != value)
            {
                prezime = value;
                OnPropertyChanged();
            }
        }
    }

    public string JMBG
    {
        get => jmbg;
        set
        {
            if (jmbg != value)
            {
                jmbg = value;
                OnPropertyChanged();
            }
        }
    }

    public DateTime DatumRodjenja
    {
        get => datumRodjenja;
        set
        {
            if (datumRodjenja != value)
            {
                datumRodjenja = value;
                OnPropertyChanged();
            }
        }
    }

    public Polovi Pol
    {
        get => pol;
        set
        {
            if (pol != value)
            {
                pol = value;
                OnPropertyChanged();
            }
        }
    }

    public int? IdNaloga
    {
        get => idNaloga;
        set
        {
            if (idNaloga != value)
            {
                idNaloga = value;
                OnPropertyChanged();
            }
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
        DatumRodjenja = new DateTime(datumRodjenja, new TimeOnly(0, 0, 0));
        Pol = pol;
        IdNaloga = null;
    }

    public OsobaViewModel(int id, string ime, string prezime, string jmbg, DateOnly datumRodjenja, Polovi pol, int idNaloga)
    {
        Id = id;
        Ime = ime;
        Prezime = prezime;
        JMBG = jmbg;
        DatumRodjenja = new DateTime(datumRodjenja, new TimeOnly(0, 0, 0));
        Pol = pol;
        IdNaloga = idNaloga;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
