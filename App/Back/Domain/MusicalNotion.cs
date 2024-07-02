namespace App.Back.Domain
{
    public class MusicalNotion
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int MusicalGenreId { get; set; }
        public int ProfileImageId { get; set; }

        public MusicalNotion() { }
        public MusicalNotion(int id, string description, int musicalGenreId, int profileImageId)
        {
            Id = id;
            Description = description;
            MusicalGenreId = musicalGenreId;
            ProfileImageId = profileImageId;
        }
        public MusicalNotion(MusicalNotion other)
        {
            Id = other.Id;
            Description = other.Description;
            MusicalGenreId = other.MusicalGenreId;
            ProfileImageId = other.ProfileImageId;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            MusicalNotion other = (MusicalNotion)obj;
            return Id == other.Id &&
                   Description == other.Description &&
                   MusicalGenreId == other.MusicalGenreId &&
                   ProfileImageId == other.ProfileImageId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Id.GetHashCode();
                hash = hash * 23 + (Description != null ? Description.GetHashCode() : 0);
                hash = hash * 23 + MusicalGenreId.GetHashCode();
                hash = hash * 23 + ProfileImageId.GetHashCode();
                return hash;
            }
        }
    }
}
