using App.Back.Domain;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;
using App.Back.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Back.Repository
{
    public class MusicalGenreRepository : Repository<MusicalGenre>, IRepository<MusicalGenre>
    {
        public MusicalGenreRepository()
        {
            SetFileName("MusicalGenreData.json");
        }
        public MusicalGenre? Create(MusicalGenre newMusicalGenre)
        {
            var instances = Load();
            newMusicalGenre.Id = Utils.GenerateId();
            instances.Add(newMusicalGenre);
            Save(instances);

            return newMusicalGenre;
        }

        public MusicalGenre? Delete(MusicalGenre instance)
        {
            throw new NotImplementedException();
        }

        public MusicalGenre? Get(MusicalGenre instance)
        {
            throw new NotImplementedException();
        }

        public List<MusicalGenre> GetAll()
        {
            return Load();
        }

        public MusicalGenre? Update(MusicalGenre instance)
        {
            throw new NotImplementedException();
        }
    }
}
