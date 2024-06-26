using App.Back.Domain;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;

namespace App.Back.Repository
{
    public class NalogRepository : Repository<Nalog>, IRepository<Nalog>
    {
        private List<Nalog> _nalozi;
        public NalogRepository()
        {
            SetFileName("NalogData.json");
            Load();
            _nalozi = _instances;
        }
        public Nalog? Create(Nalog instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance != null) { return null; }

            _instances.Add(instance);
            Save();

            return instance;
        }

        public Nalog? Delete(Nalog instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            _instances.Remove(instance);
            Save();

            return instance;
        }

        public Nalog? Get(Nalog instance)
        {
            foreach (var nalog in _nalozi)
            {
                if (nalog.Id == instance.Id)
                {
                    return nalog;
                }
            }
            return null;
        }

        public List<Nalog> GetAll()
        {
            return _nalozi;
        }

        public Nalog? Update(Nalog instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            _instances.Remove(fetchedInstance);
            _instances.Add(instance);
            Save();

            return instance;
        }
    }
}
