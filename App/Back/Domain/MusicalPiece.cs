using System.Numerics;

namespace App.Back.Domain
{
    public class MusicalPiece : MusicalNotion
    {
        public List<int> Pictures { get; set; }
        public MusicalPiece() : base()
        {
            Pictures = new();
        }
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
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            MusicalPiece other = (MusicalPiece)obj;
            return base.Equals(obj) &&
                   Pictures.SequenceEqual(other.Pictures);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = base.GetHashCode();
                foreach (var picture in Pictures)
                {
                    hash = hash * 23 + picture.GetHashCode();
                }
                return hash;
            }
        }
    }
}
