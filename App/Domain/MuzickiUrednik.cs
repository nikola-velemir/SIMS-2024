namespace App.Domain
{
    public class MuzickiUrednik : Osoba
    {
        public MuzickiUrednik(string ime, string prezime, string jMBG, DateOnly datumRodjenja, Polovi pol) : base(ime, prezime, jMBG, datumRodjenja, pol) { }
        public MuzickiUrednik(string ime, string prezime, string jMBG, DateOnly datumRodjenja, Polovi pol, int idNaloga) : base(ime, prezime, jMBG, datumRodjenja, pol, idNaloga) { }
        public MuzickiUrednik(MuzickiUrednik other)
        {
            Ime = other.Ime;
            Prezime = other.Prezime;
            JMBG = other.JMBG;
            DatumRodjenja = other.DatumRodjenja;
            Pol = other.Pol;
            IdNaloga = other.IdNaloga;
        }

        public void dodajMuzickoDelo() { 
    }
}
