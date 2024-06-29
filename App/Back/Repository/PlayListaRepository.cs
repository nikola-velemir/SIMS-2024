using App.Back.Domain;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;

namespace App.Back.Repository
{
    public class PlayListaRepository : Repository<PlayLista>, IRepository<PlayLista>
    {
        public PlayListaRepository()
        {
            SetFileName("PlayLista.json");
        }
        public PlayLista? Create(PlayLista instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance != null) { return null; }

            var instances = GetAll();
            instances.Add(instance);
            Save(instances);

            return instance;
        }

        public PlayLista? Delete(PlayLista instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(instance);
            Save(instances);

            return instance;
        }

        public PlayLista? Get(PlayLista instance)
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

        public List<PlayLista> GetAll()
        {
            return Load();
        }

        public List<PlayLista> GetByKorisnikId(int korisnikId)
        {
            var playLists = GetAll();
            List<PlayLista> userPlayLists = new List<PlayLista>();
            foreach (var pl in playLists)
            {
                if (pl.IdKorisnika == korisnikId)
                {
                    userPlayLists.Add(pl);
                }
            }
            return userPlayLists;
        }
        public PlayLista? Update(PlayLista instance)
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
