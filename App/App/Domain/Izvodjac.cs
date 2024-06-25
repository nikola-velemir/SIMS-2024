namespace App.Domain
{
    public class Izvodjac : Osoba
    {
        public Izvodjac(string ime, string prezime, string jMBG, DateOnly datumRodjenja, Polovi pol) : base(ime, prezime, jMBG, datumRodjenja, pol)
        {
        }
        public Izvodjac(string ime, string prezime, string jMBG, DateOnly datumRodjenja, Polovi pol, int idNaloga) : base(ime, prezime, jMBG, datumRodjenja, pol,idNaloga)
        {
        }
        public Izvodjac(Izvodjac other)
        {
            Ime = other.Ime;
            Prezime = other.Prezime;
            JMBG = other.JMBG;
            DatumRodjenja = other.DatumRodjenja;
            Pol = other.Pol;
            IdNaloga = other.IdNaloga;
        }
    }
}
