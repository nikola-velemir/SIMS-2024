namespace App.Domain
{
    public class Nalog
    {
        public int Id { get; set; }
        public string Lozinka { get; set; }
        public string KorisnickoIme { get; set; }
        public bool Aktivan { get; set; }
        public TipNaloga Tip { get; set; }

        public string JMBGOsobe { get; set; }

        public Nalog(int id, string lozinka, string korisnickoIme, bool aktivan, TipNaloga tip, string jMBGOsobe)
        {
            Id = id;
            Lozinka = lozinka;
            KorisnickoIme = korisnickoIme;
            Aktivan = aktivan;
            Tip = tip;
            JMBGOsobe = jMBGOsobe;
        }
        public Nalog(Nalog other)
        {
            Id = other.Id;
            Tip = other.Tip;
            Lozinka = other.Lozinka;
            Aktivan = other.Aktivan;
            KorisnickoIme = other.KorisnickoIme;
            JMBGOsobe = other.JMBGOsobe;
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
