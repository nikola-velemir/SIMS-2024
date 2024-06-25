namespace App.Domain
{
    public class Osoba
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        public DateOnly DatumRodjenja { get; set; }
        public Polovi Pol { get; set; }
        public int? IdNaloga { get; set; }

        public Osoba() { }
        public Osoba(string ime, string prezime, string jMBG, DateOnly datumRodjenja, Polovi pol)
        {
            Ime = ime;
            Prezime = prezime;
            JMBG = jMBG;
            DatumRodjenja = datumRodjenja;
            Pol = pol;
            IdNaloga = null;
        }
        public Osoba(string ime, string prezime, string jMBG, DateOnly datumRodjenja, Polovi pol, int idNaloga)
        {
            Ime = ime;
            Prezime = prezime;
            JMBG = jMBG;
            DatumRodjenja = datumRodjenja;
            Pol = pol;
            IdNaloga = idNaloga;
        }
    }
}
