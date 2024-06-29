using App.Back.Domain.Osobe;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;
using App.Back.Utilities;

namespace App.Back.Repository
{
    public class OsobaRepository : Repository<Osoba>, IRepository<Osoba>
    {
        public OsobaRepository()
        {
            SetFileName("OsobaData.json");
        }
        public Osoba? Create(Osoba instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance != null) { return null; }

            var instances = GetAll();
            instance.Id = Utils.GenerateId();
            instances.Add(instance);
            Save(instances);

            return instance;
        }

        public Osoba? Delete(Osoba instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(instance);
            Save(instances);

            return instance;
        }

        public Osoba? Get(Osoba instance)
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

        public Osoba? Update(Osoba instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(fetchedInstance);
            instances.Add(instance);
            Save(instances);

            return instance;
        }

        public List<Osoba> GetAll()
        {
            return Load();
        }
    }
}
