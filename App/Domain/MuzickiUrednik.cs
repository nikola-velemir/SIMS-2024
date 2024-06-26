namespace App.Domain
{
    public class MuzickiUrednik : Osoba
    {
        public MuzickiUrednik(int id, string ime, string prezime, string jmbg, DateOnly datumRodjenja, Polovi pol) : base(id, ime, prezime, jmbg, datumRodjenja, pol) { }
        public MuzickiUrednik(int id, string ime, string prezime, string jmbg, DateOnly datumRodjenja, Polovi pol, int idNaloga) : base(id, ime, prezime, jmbg, datumRodjenja, pol, idNaloga) { }
        public MuzickiUrednik(MuzickiUrednik other)
        {
            Ime = other.Ime;
            Prezime = other.Prezime;
            JMBG = other.JMBG;
            DatumRodjenja = other.DatumRodjenja;
            Pol = other.Pol;
            IdNaloga = other.IdNaloga;
        }

        public void dodajMuzickoDelo(MuzickoDelo delo) { 
    }
}
