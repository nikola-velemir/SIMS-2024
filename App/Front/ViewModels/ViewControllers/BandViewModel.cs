using App.Back.Domain;
using App.Back.Domain.Osobe;
using App.Back.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Front.ViewModels.ViewControllers
{
    public class BandViewModel
    {
        private BandService _bandService;
        public BandViewModel()
        {
            _bandService = new BandService();
        }
        public List<Band> GetAllBands()
        {
            return _bandService.GetAll();
        }

        public void DeleteBand(Band band)
        {
            _bandService.Delete(band);
        }

        public void UpdateBand(Band band)
        {
            _bandService.Update(band);
        }

        public void CreateBand(Band band)
        {
            _bandService.Create(band);
        }
    }
}
