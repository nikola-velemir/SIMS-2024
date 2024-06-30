using App.Back.Service;
using App.Front.ViewModels.Presentation;
using System.Windows;

namespace App.Front.ViewModels.ViewControllers
{
    public class KreiranjeIzvodjacaViewModel
    {
        public IzvodjacViewModel Izvodjac { get; set; }

        public KreiranjeIzvodjacaViewModel()
        {
            Izvodjac = new();
        }
        public bool Submit()
        {
            if (Izvodjac.IsValid)
            {
                var izvodjacService = new IzvodjacService();
                if (izvodjacService.Create(Izvodjac.ToIzvodjac()) == null)
                {
                    throw new Exception();
                }
                MessageBox.Show("Izvodjac kreiran!");
                return true;
            }
            return false;
        }
    }
}
