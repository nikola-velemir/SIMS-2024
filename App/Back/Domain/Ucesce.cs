using App.Back.Domain.Osobe;

namespace App.Back.Domain
{
    public class Ucesce
    {
        public int IdDela { get; set; }
        public int IdIzvodjaca { get; set; }
        public int IdTipaUcesnika { get; set; }
       
        public Ucesce() { }
        public Ucesce(MusicalPerformance delo, Izvodjac izvodjac, TipUcesnika tipUcesnika)
        {
            IdDela = delo.Id;
            IdTipaUcesnika = tipUcesnika.Id;
            IdIzvodjaca = izvodjac.Id;
        }
        public Ucesce(int idDela, int idIzvodjaca, int idTipaUcesnika)
        {
            IdDela = idDela;
            IdIzvodjaca = idIzvodjaca;
            IdTipaUcesnika = IdTipaUcesnika;
        }
        public Ucesce(Ucesce other)
        {
            IdDela = other.IdDela;
            IdIzvodjaca = other.IdIzvodjaca;
            IdTipaUcesnika = other.IdTipaUcesnika;
        }
    }
}
