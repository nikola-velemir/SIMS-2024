using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Back.Domain;
using App.Back.Domain.Osobe;
using App.Back.Service;

namespace App.Front.ViewModels.ViewControllers
{
    public class MusicianViewModel
    {
        private PerformerService _musicalPerformerService;
        public MusicianViewModel()
        {
            _musicalPerformerService = new PerformerService();
        }
        public List<Performer> GetAllMusicians()
        {
            return _musicalPerformerService.GetAll();
        }

        public void DeleteMusician(Performer performer)
        {
            _musicalPerformerService.Delete(performer);
        }

        public void UpdateMusician(Performer performer)
        {
            _musicalPerformerService.Update(performer);
        }
    }
}
