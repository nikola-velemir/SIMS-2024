using App.Back.Domain;
using App.Back.Repository;

namespace App.Back.Service
{
    public class MusicalGenreService
    {
        private MusicalGenreRepository _musicalGenreRepository;
        public MusicalGenreService()
        {
            _musicalGenreRepository = new MusicalGenreRepository();
        }

        public List<MusicalGenre> GetAll()
        {
            return _musicalGenreRepository.GetAll();
        }

        public MusicalGenre? Create(MusicalGenre newGenre)
        {
            return _musicalGenreRepository.Create(newGenre);
        }

        public MusicalGenre? GetByName(string name)
        {
            foreach(MusicalGenre musicalGenre in _musicalGenreRepository.GetAll())
            {
                if(musicalGenre.Name == name)
                {
                    return musicalGenre;
                }
            }
            return null;
        }
    }
}
