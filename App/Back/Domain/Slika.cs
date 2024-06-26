namespace App.Back.Domain
{
    public class Slika
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public string Path { get; set; }
        public Slika(int id, string opis, string path)
        {
            Id = id;
            Opis = opis;
            Path = path;
        }
    }
}
