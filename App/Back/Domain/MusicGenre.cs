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

        public override bool Equals(object? obj)
        {
            return obj is MusicGenre genre &&
                   Id == genre.Id &&
                   Name == genre.Name;
        }
    }
}
