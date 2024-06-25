namespace App.Domain
{
    public class Izvodjenje : MuzickiPojam
    {
        public DateOnly Datum { get; set; }
        public bool Uzivo { get; set; }

        public List<MuzickoDelo> Dela { get; set; }
        public List<Izvodjac> Izvodjaci { get; set; }
        public List<Slika> Slike { get; set; }
        public Izvodjenje(int id, 
            string opis,
            DateOnly datum,
            bool uzivo, List<MuzickoDelo> dela, List<Izvodjac> izvodjaci, List<Slika> slike) : base(id, opis)
        {
            Datum = datum;
            Uzivo = uzivo;
            Dela = dela;
            Izvodjaci = izvodjaci;
            Slike = slike;
        }
        public void DodajIzvodjaca(Izvodjac izvodjac)
        {
            Izvodjaci.Add(izvodjac);
        }
        public void DodajSliku(Slika slika)
        {
            Slike.Add(slika);
        }
        public void DodajDelo(MuzickoDelo delo)
        {
            Dela.Add(delo); 
        }
    }
}
