namespace App.Domain
{
    public class Biografija
    {
        public int Id { get; set; }
        public string Tekst { get; set; }
        public List<Slika> Slike { get; set; }

        public Biografija(int id, string tekst, List<Slika> slike)
        {
            Tekst = tekst;
            Slike = slike;
            Id = id;
        }
        public Biografija(Biografija other)
        {
            Tekst = other.Tekst;
            Slike = other.Slike;
            Id = other.Id;
        }

    }
}
