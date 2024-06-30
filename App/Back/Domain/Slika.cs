namespace App.Back.Domain
{
    public class Slika
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public Slika(int id, string description, string path)
        {
            Id = id;
            Description = description;
            Path = path;
        }
    }
}
