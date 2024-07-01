using App.Back.Domain.State.Recenzije;
using App.Back.Domain.State.Recenzije.Base;

namespace App.Back.Domain
{
    public class Review
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool EditiorPriority { get; set; }
        public DateOnly Date { get; set;}
        
        public int AccountId { get; set; }
        public int MusicalNotionId { get; set; }

        public Rating Rating { get; set; }
        
        public StanjeRecenzije State { get; set; }

        public bool GaveUpOnWriting { get; set; }
        public bool AcceptedReview { get; set; }
        public bool WantsToEdit { get; set; }
        public Review() {
            Description = string.Empty;
            Rating = new();
            State = new DraftRecenzija();
        }
        public Review(int id, string opis, bool urednikPriorited, DateOnly datum, int idKorisnika, int idMuzickogPojma, Rating rejting, StanjeRecenzije stanje, bool odustaoOdPisanja, bool prihvatioRecenziju, bool hoceDaIzmeni)
        {
            Id = id;
            Description = opis;
            EditiorPriority = urednikPriorited;
            Date = datum;
            AccountId = idKorisnika;
            MusicalNotionId = idMuzickogPojma;
            Rating = rejting;
            State = stanje;
            GaveUpOnWriting = odustaoOdPisanja;
            AcceptedReview = prihvatioRecenziju;
            WantsToEdit = hoceDaIzmeni;
        }
        public Review(int id, string opis, bool urednikPriorited, DateOnly datum, int idKorisnika, int idMuzickogPojma, Rating rejting)
        {
            Id = id;
            Description = opis;
            EditiorPriority = urednikPriorited;
            Date = datum;
            AccountId = idKorisnika;
            MusicalNotionId = idMuzickogPojma;
            Rating = rejting;
            State = new DraftRecenzija();
            GaveUpOnWriting = false;
            AcceptedReview = false;
            WantsToEdit = false;
        }
    }
}
