namespace App.Domain
{
    public class Biografija
    {
        public string Tekst { get; set; }
        public List<Slika> Slike { get; set; }

        public Biografija(string tekst, List<Slika> slike)
        {
            Tekst = tekst;
            Slike = slike;
        }
        public Biografija(Biografija other)
        {
            Tekst = other.Tekst;
            Slike = other.Slike;
        }

    }
}
