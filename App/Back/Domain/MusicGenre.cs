namespace App.Back.Domain
{
    public class MusicGenre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MusicGenre(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public MusicGenre() { }

    }
}
