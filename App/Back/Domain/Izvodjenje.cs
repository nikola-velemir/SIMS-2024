using App.Back.Domain.Osobe;

namespace App.Back.Domain
{
    public class Izvodjenje : MuzickiPojam
    {
        public DateOnly Datum { get; set; }
        public bool Uzivo { get; set; }

        public List<int> Dela { get; set; }
        public List<int> Izvodjaci { get; set; }
        public List<int> Slike { get; set; }
        public Izvodjenje(int id,
            string opis,
            DateOnly datum,
            bool uzivo, List<int> dela, List<int> izvodjaci, List<int> slike) : base(id, opis)
        {
            Datum = datum;
            Uzivo = uzivo;
            Dela = dela;
            Izvodjaci = izvodjaci;
            Slike = slike;
        }
        public void DodajIzvodjaca(Izvodjac izvodjac)
        {
            foreach (var i in Izvodjaci)
            {
                if (i == izvodjac.Id) { return; }
            }
            Izvodjaci.Add(izvodjac.Id);
        }
        public void DodajSliku(Slika slika)
        {
            foreach (var i in Slike)
            {
                if (i == slika.Id) { return; }
            }
            Slike.Add(slika.Id);
        }
        public void DodajDelo(MuzickoDelo delo)
        {
            foreach (var i in Dela)
            {
                if (i == delo.Id) { return; }
            }
            Dela.Add(delo.Id);
        }
    }
}
