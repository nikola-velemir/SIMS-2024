using App.Front.ViewModels.Presentation;

namespace App.Front.ViewModels.ViewControllers
{
    public class KreiranjeIzvodjacaViewModel
    {
        public IzvodjacViewModel Izvodjac { get; set; }

        public KreiranjeIzvodjacaViewModel()
        {
            Izvodjac = new();
        }
    }
}
