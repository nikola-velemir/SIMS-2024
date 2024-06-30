using App.Back.Domain;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;

namespace App.Back.Repository
{
    public class PlayListRepository : Repository<PlayList>, IRepository<PlayList>
    {
        public PlayListRepository()
        {
            SetFileName("PlayLista.json");
        }
        public PlayList? Create(PlayList instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance != null) { return null; }

            var instances = GetAll();
            instances.Add(instance);
            Save(instances);

            return instance;
        }

        public PlayList? Delete(PlayList instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(instance);
            Save(instances);

            return instance;
        }

        public PlayList? Get(PlayList instance)
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

        public List<PlayList> GetAll()
        {
            return Load();
        }

        public List<PlayList> GetByUserId(int userId)
        {
            var playLists = GetAll();
            List<PlayList> userPlayLists = new List<PlayList>();
            foreach (var pl in playLists)
            {
                if (pl.AccountId == userId)
                {
                    userPlayLists.Add(pl);
                }
            }
            return userPlayLists;
        }
        public PlayList? Update(PlayList instance)
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
