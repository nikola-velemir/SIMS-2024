namespace App.Domain
{
    public class MuzickoDelo : MuzickiPojam
    {
        public List<int> Slike { get; set; }
        public MuzickoDelo(int id, string opis, List<int> slike) : base(id, opis)
        {
            Slike = slike;
        }
        public void DodajSliku(Slika slika)
        {
            Slike.Add(slika.Id);
        }
    }
}
