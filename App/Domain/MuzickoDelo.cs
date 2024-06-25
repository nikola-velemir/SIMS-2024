namespace App.Domain
{
    public class MuzickoDelo : MuzickiPojam
    {
        public List<Slika> Slike { get; set; }
        public MuzickoDelo(int id, string opis, List<Slika> slike) : base(id, opis)
        {
            Slike = slike;
        }
        public void DodajSliku(Slika slika)
        {
            Slike.Add(slika);
        }
    }
}
