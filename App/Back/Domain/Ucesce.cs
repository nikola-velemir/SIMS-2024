namespace App.Back.Domain
{
    public class Ucesce
    {
        public MuzickoDelo Delo { get; set; }
        public Izvodjac Izvodjac { get; set; }
        public Ucesce(MuzickoDelo delo, Izvodjac izvodjac)
        {
            Delo = delo;
            Izvodjac = izvodjac;
        }
        public Ucesce(Ucesce other)
        {
            Delo = other.Delo;
            Izvodjac = other.Izvodjac;
        }
    }
}
