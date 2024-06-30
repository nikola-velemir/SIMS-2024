using App.Back.Domain;
using App.Back.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
