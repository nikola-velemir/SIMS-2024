using App.Back.Domain;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;
using App.Back.Utilities;

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
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(instance);
            Save(instances);

            return instance;
        }

        public MusicalGenre? Get(MusicalGenre instance)
        {
            foreach (var izvodjac in GetAll())
            {
                if (izvodjac.Id == instance.Id)
                {
                    return izvodjac;
                }
            }
            return null;
        }

        public List<MusicalGenre> GetAll()
        {
            return Load();
        }

        public MusicalGenre? Update(MusicalGenre instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(fetchedInstance);
            instances.Add(instance);
            Save(instances);

            return instance;
        }
    }
}
