using App.Back.Domain.Osobe;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;
using App.Back.Utilities;

namespace App.Back.Repository
{
    public class PerformerRepository : Repository<Performer>, IRepository<Performer>
    {
        public PerformerRepository()
        {
            SetFileName("PerformerData.json");
        }
        public Performer? Create(Performer instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance != null) { return null; }

            var instances = Load();
            instance.Id = Utils.GenerateId();
            instances.Add(instance);
            Save(instances);

            return instance;
        }

        public Performer? Delete(Performer instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }
            
            var instances = Load();
            instances.Remove(instance);
            Save(instances);
            
            return instance;
        }

        public Performer? Get(Performer instance)
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

        public Performer? Update(Performer instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(fetchedInstance);
            instances.Add(instance);
            Save(instances);

            return instance;
        }

        public List<Performer> GetAll()
        {
            return Load();
        }
    }
}
