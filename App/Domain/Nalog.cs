namespace App.Domain
{
    public class Nalog
    {
        public int Id { get; set; }
        public string Lozinka { get; set; }
        public string KorisnickoIme { get; set; }
        public bool Aktivan { get; set; }
        public TipNaloga Tip { get; set; }

        public int IdOsobe { get; set; }

        public Nalog(int id, string lozinka, string korisnickoIme, bool aktivan, TipNaloga tip, int idOsobe)
        {
            Id = id;
            Lozinka = lozinka;
            KorisnickoIme = korisnickoIme;
            Aktivan = aktivan;
            Tip = tip;
            IdOsobe = idOsobe;
        }
        public Nalog(Nalog other)
        {
            Id = other.Id;
            Tip = other.Tip;
            Lozinka = other.Lozinka;
            Aktivan = other.Aktivan;
            KorisnickoIme = other.KorisnickoIme;
            IdOsobe = other.IdOsobe;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            return GetHashCode() == obj.GetHashCode();
        }
        //public override int GetHashCode()
        //{

        //}
    }
}
