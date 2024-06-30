using App.Back.Domain;
using App.Back.Service;

namespace App.Front.ViewModels.ViewControllers
{
    public class MusicalPerformanceViewModel
    {
        private MusicalPerformanceService _musicalPerformanceService;
        private PictureService _pictureService;
        private MusicalGenreService _musicalGenreService;
        public MusicalPerformanceViewModel() 
        {
            _musicalPerformanceService = new MusicalPerformanceService();
            _pictureService = new PictureService();
            _musicalGenreService = new MusicalGenreService();
        }

        public Picture? CreatePicture(Picture newPicture)
        {
            return _pictureService.Create(newPicture);
        }

        public MusicalPiece? CreateMusicalPerformance(MusicalPiece newMusicalPerformance)
        {
            return _musicalPerformanceService.Create(newMusicalPerformance);
        }

        public List<MusicalGenre> GetAllMusicalGenre()
        {
            return _musicalGenreService.GetAll();
        }

        public int GetIdByGenreName(string name)
        {
            var genre = _musicalGenreService.GetByName(name);
            if (genre != null)
            {
                return genre.Id;
            }
            return -1;
        }


    }
}
