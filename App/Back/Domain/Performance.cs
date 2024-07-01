using App.Back.Domain.Osobe;

namespace App.Back.Domain
{
    public class Performance : MusicalNotion
    {
        public DateOnly Date { get; set; }
        public bool Live { get; set; }

        public List<int> Piece { get; set; }
        public List<int> Performers { get; set; }
        public List<int> Pictures { get; set; }
        public int ProfilePictureId { get; set; }
        public Performance()
        {
            Piece = new List<int>();
            Performers = new List<int>();
            Pictures = new List<int>();
        }
        public Performance(int id,
            string descirption,
            DateOnly date,
            int musicalGenreId,
            bool live, List<int> pieces, List<int> performers, List<int> pictures, int profilePictureId) : base(id, descirption, musicalGenreId, profilePictureId)
        {
            Date = date;
            Live = live;
            Piece = pieces;
            Performers = performers;
            Pictures = pictures;
            ProfilePictureId = profilePictureId;
        }
        public void DodajIzvodjaca(Performer performer)
        {
            foreach (var i in Performers)
            {
                if (i == performer.Id) { return; }
            }
            Performers.Add(performer.Id);
        }
        public void DodajSliku(Picture slika)
        {
            foreach (var i in Pictures)
            {
                if (i == slika.Id) { return; }
            }
            Pictures.Add(slika.Id);
        }
        public void DodajDelo(MusicalPiece delo)
        {
            foreach (var i in Piece)
            {
                if (i == delo.Id) { return; }
            }
            Piece.Add(delo.Id);
        }
    }
}
