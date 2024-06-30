namespace App.Back.Domain
{
    public class PlayList
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public List<int> Pesme { get; set; }

        public PlayList()
        {
            Pesme = new List<int>();
        }
        public PlayList(int id, int accountId, List<int> pieces)
        {
            Id = id;
            AccountId = accountId;
            Pesme = pieces;
        }
        public PlayList(int id, UserAccount user, List<MusicalPiece> pieces)
        {
            Id = id;
            AccountId = user.Id;
            Pesme = new List<int>();
            FillPesme(pieces);

        }
        public PlayList(PlayList other)
        {
            Id = other.Id;  
            AccountId = other.AccountId;
            Pesme = new(other.Pesme);
        }
        private void FillPesme(List<MusicalPiece> pieces)
        {
            foreach (MusicalPiece md in pieces)
            {
                if (Pesme.Contains(md.Id))
                    Pesme.Add(md.Id);
            }
        }
    }
}
