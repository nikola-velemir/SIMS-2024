
namespace App.Back.Domain.Osobe
{
    public class MusicEditor
    {
        public List<int> Genres {  get; set; }
        public int PersonId {  get; set; }
        public int AccountId {  get; set; }
        public int Id {  get; set; }

        public MusicEditor() { }
        public MusicEditor(List<int> genres, int personId, int accountId)
        {
            Genres = genres;
            PersonId = personId;
            AccountId = accountId;
        }


        public MusicEditor(MusicEditor other)
        {
            Genres = other.Genres;
            PersonId = other.PersonId;
            AccountId = other.AccountId;
        }
        public void dodajMuzickoDelo(MusicalPiece delo)
        {
        }

        public override bool Equals(object? obj)
        {
            return obj is MusicEditor editor &&
                   PersonId == editor.PersonId &&
                   AccountId == editor.AccountId &&
                   Id == editor.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PersonId, AccountId, Id);
        }
    }
}
