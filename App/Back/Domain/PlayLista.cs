namespace App.Back.Domain
{
    public class PlayLista
    {
        public int Id { get; set; }
        public int IdKorisnika { get; set; }
        public List<int> Pesme { get; set; }

        public PlayLista()
        {
            Pesme = new List<int>();
        }
        public PlayLista(int id, int idKorisnika, List<int> pesme)
        {
            Id = id;
            IdKorisnika = idKorisnika;
            Pesme = pesme;
        }
        public PlayLista(int id, Nalog korisnik, List<MuzickoDelo> pesme)
        {
            Id = id;
            IdKorisnika = korisnik.Id;
            Pesme = new List<int>();
            FillPesme(pesme);

        }
        public PlayLista(PlayLista other)
        {
            Id = other.Id;  
            IdKorisnika = other.IdKorisnika;
            Pesme = new(other.Pesme);
        }
        private void FillPesme(List<MuzickoDelo> pesme)
        {
            foreach (MuzickoDelo md in pesme)
            {
                if (Pesme.Contains(md.Id))
                    Pesme.Add(md.Id);
            }
        }
    }
}
