using App.Back.Domain;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;

namespace App.Back.Repository
{
    public class IzvodjacRepository : Repository<Izvodjac>, IRepository<Izvodjac>
    {
        private List<Izvodjac> _izvodjaci { get; set; }
        public IzvodjacRepository()
        {
            SetFileName("IzvodjacData.json");
            Load();
            _izvodjaci = _instances;

        }
        public Izvodjac? Create(Izvodjac instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance != null) { return null; }

            _instances.Add(instance);
            Save();

            return instance;
        }

        public Izvodjac? Delete(Izvodjac instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            _instances.Remove(instance);
            Save();

            return instance;
        }

        public Izvodjac? Get(Izvodjac instance)
        {
            foreach (var izvodjac in _izvodjaci)
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

            _instances.Remove(fetchedInstance);
            _instances.Add(instance);
            Save();

            return instance;
        }

        public List<Izvodjac> GetAll()
        {
            return _instances;
        }
    }
}
