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

        public List<MusicGenre> GetAll()
        {
            return _musicalGenreRepository.GetAll();
        }
        public MusicGenre? GetById(int id)
        {
            foreach (var g in _musicalGenreRepository.GetAll())
            {
                if (g.Id == id) return g;
            }
            return null;

        }
        public MusicGenre? Create(MusicGenre newGenre)
        {
            return _musicalGenreRepository.Create(newGenre);
        }

        public MusicGenre? GetByName(string name)
        {
            foreach (MusicGenre musicalGenre in _musicalGenreRepository.GetAll())
            {
                if (musicalGenre.Name == name)
                {
                    return musicalGenre;
                }
            }
            return null;
        }
    }
}
