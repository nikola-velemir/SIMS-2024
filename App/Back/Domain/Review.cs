using App.Back.Domain.State.Recenzije;
using App.Back.Domain.State.Recenzije.Base;

namespace App.Back.Domain
{
    public class Review
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool EditorPriority { get; set; }
        public DateOnly Date { get; set; }

        public int AccountId { get; set; }
        public int MusicalNotionId { get; set; }

        public Rating Rating { get; set; }

        public StanjeRecenzije State { get; set; }

        public bool GaveUpOnWriting { get; set; }
        public bool AcceptedReview { get; set; }
        public bool WantsToEdit { get; set; }
        public Review()
        {
            Description = string.Empty;
            Rating = new();
            State = new DraftRecenzija();
        }
        public Review(int id, string opis, bool urednikPriorited, DateOnly datum, int idKorisnika, int idMuzickogPojma, Rating rejting, StanjeRecenzije stanje, bool odustaoOdPisanja, bool prihvatioRecenziju, bool hoceDaIzmeni)
        {
            Id = id;
            Description = opis;
            EditorPriority = urednikPriorited;
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
            EditorPriority = urednikPriorited;
            Date = datum;
            AccountId = idKorisnika;
            MusicalNotionId = idMuzickogPojma;
            Rating = rejting;
            State = new DraftRecenzija();
            GaveUpOnWriting = false;
            AcceptedReview = false;
            WantsToEdit = false;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Review other = (Review)obj;
            return Id == other.Id &&
                   Description == other.Description &&
                   EditorPriority == other.EditorPriority &&
                   Date == other.Date &&
                   AccountId == other.AccountId &&
                   MusicalNotionId == other.MusicalNotionId &&
                   Rating.Equals(other.Rating) &&
                   State.Equals(other.State) &&
                   GaveUpOnWriting == other.GaveUpOnWriting &&
                   AcceptedReview == other.AcceptedReview &&
                   WantsToEdit == other.WantsToEdit;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Id.GetHashCode();
            hash = hash * 23 + (Description?.GetHashCode() ?? 0);
            hash = hash * 23 + EditorPriority.GetHashCode();
            hash = hash * 23 + Date.GetHashCode();
            hash = hash * 23 + AccountId.GetHashCode();
            hash = hash * 23 + MusicalNotionId.GetHashCode();
            hash = hash * 23 + Rating.GetHashCode();
            hash = hash * 23 + State.GetHashCode();
            hash = hash * 23 + GaveUpOnWriting.GetHashCode();
            hash = hash * 23 + AcceptedReview.GetHashCode();
            hash = hash * 23 + WantsToEdit.GetHashCode();
            return hash;
        }
    }
}