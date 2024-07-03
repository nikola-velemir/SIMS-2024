using App.Back.Domain;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;
using App.Back.Utilities;

namespace App.Back.Repository
{
    public class MusicalGenreRepository : Repository<MusicGenre>, IRepository<MusicGenre>
    {
        public MusicalGenreRepository()
        {
            SetFileName("MusicalGenreData.json");
        }
        public MusicGenre? Create(MusicGenre newMusicalGenre)
        {
            var instances = Load();
            newMusicalGenre.Id = Utils.GenerateId();
            instances.Add(newMusicalGenre);
            Save(instances);

            return newMusicalGenre;
        }

        public MusicGenre? Delete(MusicGenre instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(instance);
            Save(instances);

            return instance;
        }

        public MusicGenre? Get(MusicGenre instance)
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

        public List<MusicGenre> GetAll()
        {
            return Load();
        }

        public MusicGenre? Update(MusicGenre instance)
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
