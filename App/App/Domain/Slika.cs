namespace App.Domain
{
    public class Slika
    {
        public string Opis { get; set; }
        public string Path { get; set; }
        public Slika(string opis, string path)
        {
            Opis = opis;
            Path = path;
        }
    }
}
