using App.Back.Domain.State.Recenzije;
using App.Back.Domain.State.Recenzije.Base;

namespace App.Back.Domain
{
    public class Recenzija
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public bool UrednikPriorited { get; set; }
        public DateOnly Datum { get; set;}
        
        public int IdKorisnika { get; set; }
        public int IdMuzickogPojma { get; set; }

        public Rejting Rejting { get; set; }
        
        public StanjeRecenzije Stanje { get; set; }

        public bool OdustaoOdPisanja { get; set; }
        public bool PrihvatioRecenziju { get; set; }
        public bool HoceDaIzmeni { get; set; }
        public Recenzija() {
            Opis = string.Empty;
            Rejting = new();
            Stanje = new DraftRecenzija();
        }
        public Recenzija(int id, string opis, bool urednikPriorited, DateOnly datum, int idKorisnika, int idMuzickogPojma, Rejting rejting, StanjeRecenzije stanje, bool odustaoOdPisanja, bool prihvatioRecenziju, bool hoceDaIzmeni)
        {
            Id = id;
            Opis = opis;
            UrednikPriorited = urednikPriorited;
            Datum = datum;
            IdKorisnika = idKorisnika;
            IdMuzickogPojma = idMuzickogPojma;
            Rejting = rejting;
            Stanje = stanje;
            OdustaoOdPisanja = odustaoOdPisanja;
            PrihvatioRecenziju = prihvatioRecenziju;
            HoceDaIzmeni = hoceDaIzmeni;
        }
        public Recenzija(int id, string opis, bool urednikPriorited, DateOnly datum, int idKorisnika, int idMuzickogPojma, Rejting rejting)
        {
            Id = id;
            Opis = opis;
            UrednikPriorited = urednikPriorited;
            Datum = datum;
            IdKorisnika = idKorisnika;
            IdMuzickogPojma = idMuzickogPojma;
            Rejting = rejting;
            Stanje = new DraftRecenzija();
            OdustaoOdPisanja = false;
            PrihvatioRecenziju = false;
            HoceDaIzmeni = false;
        }
    }
}
