using App.Back.Service;
using App.Front.ViewModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Front.ViewModels.ViewControllers
{
    public class MusicalGenreViewModel
    {
        private MusicalGenreService _musicalGenreService;
        public MusicalGenreViewModel()
        {
            _musicalGenreService = new MusicalGenreService();
        }

        public MusicalGenreDTO? Create(MusicalGenreDTO newMusicalGenre)
        {
            return _musicalGenreService.Create(newMusicalGenre.ToMusicGenre());
        }

        public MusicalGenreDTO? Update(MusicalGenreDTO newMusicalGenre)
        {
            return _musicalGenreService.Update(newMusicalGenre);
        }

        public void Delete(MusicalGenreDTO oldMusicalGenre)
        {
            _musicalGenreService.Delete(oldMusicalGenre); 
        }
    }
}
