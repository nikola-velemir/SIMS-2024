namespace App.Back.Domain
{
    public class MusicalPiece : MusicalNotion
    {
        public List<int> Pictures { get; set; }
        public MusicalPiece(): base() { }
        public MusicalPiece(int id, string description, List<int> pictures, int musicalGenreId) : base(id, description, musicalGenreId)
        {
            Pictures = pictures;
        }
        public void AddPicture(Picture picture)
        {
            Pictures.Add(picture.Id);
        }
    }
}
