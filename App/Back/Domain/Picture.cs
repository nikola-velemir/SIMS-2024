namespace App.Back.Domain
{
    public class Picture
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }

        public Picture() { }
        public Picture(int id, string description, string path)
        {
            Id = id;
            Description = description;
            Path = path;
        }
    }
}
