namespace App.Back.Domain
{
    public class PlayList
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public List<int> Pieces { get; set; }
        public DateOnly DateCreated { get; set; }   
        public string Name { get; set; }    
        public PlayList()
        {
            Pieces = new List<int>();
            Name = string.Empty;
        }
        public PlayList(int id, int accountId, string name, List<int> pieces,DateOnly dateCreated)
        {
            Id = id;
            AccountId = accountId;
            Pieces = pieces;
            Name = name;
            DateCreated = dateCreated;
        }
        public PlayList(int id, UserAccount user, string name, List<MusicalPiece> pieces, DateOnly dateCreated)
        {
            Id = id;
            AccountId = user.Id;
            Pieces = new List<int>();
            FillPesme(pieces);
            Name = name;
            DateCreated = dateCreated;
        }
        public PlayList(PlayList other)
        {
            Id = other.Id;  
            AccountId = other.AccountId;
            Pieces = new(other.Pieces);
            Name = other.Name;
            DateCreated = other.DateCreated;
        }
        private void FillPesme(List<MusicalPiece> pieces)
        {
            foreach (MusicalPiece md in pieces)
            {
                if (Pieces.Contains(md.Id))
                    Pieces.Add(md.Id);
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            PlayList other = (PlayList)obj;
            return Id == other.Id &&
                   AccountId == other.AccountId &&
                   Pieces.SequenceEqual(other.Pieces) &&
                   DateCreated.Equals(other.DateCreated) &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Id.GetHashCode();
                hash = hash * 23 + AccountId.GetHashCode();
                hash = hash * 23 + DateCreated.GetHashCode();
                hash = hash * 23 + (Name != null ? Name.GetHashCode() : 0);
                foreach (var piece in Pieces)
                {
                    hash = hash * 23 + piece.GetHashCode();
                }
                return hash;
            }
        }
    }
}
