namespace App.Back.Domain
{
    public class MusicalNotion
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int MusicalGenreId {  get; set; }

        public MusicalNotion() { }
        public MusicalNotion(int id, string description, int musicalGenreId)
        {
            Id = id;
            Description = description;
            MusicalGenreId = musicalGenreId;
        }
    }
}
