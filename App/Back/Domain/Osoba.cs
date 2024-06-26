namespace App.Back.Domain
{
    public class Osoba
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        public DateOnly DatumRodjenja { get; set; }
        public Polovi Pol { get; set; }
        public int? IdNaloga { get; set; }

        public Osoba()
        {
            Ime = string.Empty;
            Prezime = string.Empty;
            JMBG = string.Empty;
        }
        public Osoba(int id, string ime, string prezime, string jmbg, DateOnly datumRodjenja, Polovi pol)
        {
            Id = id;
            Ime = ime;
            Prezime = prezime;
            JMBG = jmbg;
            DatumRodjenja = datumRodjenja;
            Pol = pol;
            IdNaloga = null;
        }
        public Osoba(int id, string ime, string prezime, string jmbg, DateOnly datumRodjenja, Polovi pol, int idNaloga)
        {
            Id = id;
            Ime = ime;
            Prezime = prezime;
            JMBG = jmbg;
            DatumRodjenja = datumRodjenja;
            Pol = pol;
            IdNaloga = idNaloga;
        }
    }
}
