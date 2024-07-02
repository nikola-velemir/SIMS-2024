using App.Back.Domain;
using App.Back.Repository;
using App.Front.ViewModels.DTO;

namespace App.Back.Service
{
    public class MusicalGenreService
    {
        private MusicalGenreRepository _musicalGenreRepository;
        public MusicalGenreService()
        {
            _musicalGenreRepository = new MusicalGenreRepository();
        }

        public List<MusicalGenreDTO> GetAll()
        {
            var genres = _musicalGenreRepository.GetAll();
            var genreDTOs = new List<MusicalGenreDTO>();
            foreach (var genre in genres)
            {
                genreDTOs.Add(new MusicalGenreDTO(genre));
            }
            return genreDTOs;
        }
        public MusicalGenreDTO? GetById(int id)
        {
            foreach (var g in _musicalGenreRepository.GetAll())
            {
                if (g.Id == id) return new MusicalGenreDTO(g);
            }
            return null;

        }
        public MusicalGenreDTO? Create(MusicGenre newGenre)
        {
            return new MusicalGenreDTO(_musicalGenreRepository.Create(newGenre));
        }

        public MusicalGenreDTO? GetByName(string name)
        {
            foreach (MusicGenre musicalGenre in _musicalGenreRepository.GetAll())
            {
                if (musicalGenre.Name == name)
                {
                    return new MusicalGenreDTO(musicalGenre);
                }
            }
            return null;
        }

        public MusicalGenreDTO? Update(MusicalGenreDTO newMusicalGenre)
        {
            return new MusicalGenreDTO(_musicalGenreRepository.Update(newMusicalGenre.ToMusicGenre()));
        }

        public void Delete(MusicalGenreDTO oldMusicalGenre)
        {
            _musicalGenreRepository.Delete(oldMusicalGenre.ToMusicGenre());
        }
    }
}
