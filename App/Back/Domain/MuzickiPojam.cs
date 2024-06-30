namespace App.Back.Domain
{
    public class MuzickiPojam
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int MusicalGenreId {  get; set; }

        public MuzickiPojam(int id, string description, int musicalGenreId)
        {
            Id = id;
            Description = description;
            MusicalGenreId = musicalGenreId;
        }
    }
}
