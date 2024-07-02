namespace App.Back.Domain
{
    public class MusicalPiece : MusicalNotion
    {
        public List<int> Pictures { get; set; }
        public MusicalPiece() : base() { }
        public MusicalPiece(int id, string description, List<int> pictures, int musicalGenreId, int profilePictureId) : base(id, description, musicalGenreId, profilePictureId)
        {
            Pictures = pictures;
        }
        public MusicalPiece(MusicalPiece other)
        {
            Id = other.Id;
            Description = other.Description;
            Pictures = new(other.Pictures);
            MusicalGenreId = other.MusicalGenreId;
            ProfileImageId = other.ProfileImageId;
        }
        public void AddPicture(Picture picture)
        {
            Pictures.Add(picture.Id);
        }

        public override bool Equals(object? obj)
        {
            return obj is MusicalPiece piece &&
                   Id == piece.Id;
        }
    }
}
