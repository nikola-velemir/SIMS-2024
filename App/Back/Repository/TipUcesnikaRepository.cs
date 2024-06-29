using App.Back.Domain;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;
using App.Back.Utilities;

namespace App.Back.Repository
{
    public class TipUcesnikaRepository : Repository<TipUcesnika>, IRepository<TipUcesnika>
    {
        public TipUcesnikaRepository()
        {
            SetFileName("TipUcesnika.json");
        }
        public TipUcesnika? Create(TipUcesnika instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance != null) { return null; }

            var instances = GetAll();
            instance.Id = Utils.GenerateId();
            instances.Add(instance);
            Save(instances);

            return instance;
        }

        public TipUcesnika? Delete(TipUcesnika instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(instance);
            Save(instances);

            return instance;
        }

        public TipUcesnika? Get(TipUcesnika instance)
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

        public List<TipUcesnika> GetAll()
        {
            return Load();
        }

        public TipUcesnika? Update(TipUcesnika instance)
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
