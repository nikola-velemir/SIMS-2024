using App.Back.Domain;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;
using App.Back.Utilities;

namespace App.Back.Repository
{
    public class UcesceRepository : Repository<Ucesce>, IRepository<Ucesce>
    {
        public UcesceRepository() {
            SetFileName("Ucesce.json");
        }
        public Ucesce? Create(Ucesce instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance != null) { return null; }

            var instances = GetAll();
            instances.Add(instance);
            Save(instances);

            return instance;
        }

        public Ucesce? Delete(Ucesce instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(instance);
            Save(instances);

            return instance;
        }

        public Ucesce? Get(Ucesce instance)
        {
            foreach (var izvodjac in GetAll())
            {
                if (izvodjac.IdIzvodjaca == instance.IdIzvodjaca &&
                    izvodjac.IdDela == instance.IdDela && izvodjac.IdTipaUcesnika == izvodjac.IdTipaUcesnika)
                {
                    return izvodjac;
                }
            }
            return null;
        }

        public List<Ucesce> GetAll()
        {
            return Load();
        }

        public Ucesce? Update(Ucesce instance)
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
