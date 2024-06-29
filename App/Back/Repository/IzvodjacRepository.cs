using App.Back.Domain.Osobe;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;

namespace App.Back.Repository
{
    public class IzvodjacRepository : Repository<Izvodjac>, IRepository<Izvodjac>
    {


        public IzvodjacRepository()
        {
            SetFileName("IzvodjacData.json");
        }
        public Izvodjac? Create(Izvodjac instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance != null) { return null; }

            var instances = Load();
            instances.Add(instance);
            Save(instances);

            return instance;
        }

        public Izvodjac? Delete(Izvodjac instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }
            
            var instances = Load();
            instances.Remove(instance);
            Save(instances);
            
            return instance;
        }

        public Izvodjac? Get(Izvodjac instance)
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

        public Izvodjac? Update(Izvodjac instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(fetchedInstance);
            instances.Add(instance);
            Save(instances);

            return instance;
        }

        public List<Izvodjac> GetAll()
        {
            return Load();
        }
    }
}
