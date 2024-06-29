using App.Back.Domain;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;

namespace App.Back.Repository
{
    public class NalogRepository : Repository<Nalog>, IRepository<Nalog>
    {
        public NalogRepository()
        {
            SetFileName("NalogData.json");
        }
        public Nalog? Create(Nalog instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance != null) { return null; }

            var instances = Load();
            instances.Add(instance);
            Save(instances);

            return instance;
        }

        public Nalog? Delete(Nalog instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(instance);
            Save(instances);

            return instance;
        }

        public Nalog? Get(Nalog instance)
        {
            foreach (var nalog in GetAll())
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
            return Load();
        }

        public Nalog? Update(Nalog instance)
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
