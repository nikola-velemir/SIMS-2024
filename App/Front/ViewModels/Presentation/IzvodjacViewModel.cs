using App.Back.Domain.Osobe;

namespace App.Front.ViewModels.Presentation
{
    public class IzvodjacViewModel : OsobaViewModel
    {
        public IzvodjacViewModel() : base() { }
        public IzvodjacViewModel(Izvodjac izvodjac)
        {
            Id = izvodjac.Id;
            Ime = izvodjac.Ime;
            Prezime = izvodjac.Prezime;
            JMBG = izvodjac.JMBG;
            DatumRodjenja = new DateTime(izvodjac.DatumRodjenja, new TimeOnly(0, 0, 0));
            Pol = izvodjac.Pol;
        }
        public Izvodjac ToIzvodjac()
        {
            return new Izvodjac(Id, Ime, Prezime, JMBG, DateOnly.FromDateTime(DatumRodjenja), Pol);
        }
    }
}
