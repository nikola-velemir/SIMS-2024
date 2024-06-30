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
    }
}
