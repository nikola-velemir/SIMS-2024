using App.Back.Domain;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;
using App.Back.Utilities;

namespace App.Back.Repository
{
    public class PerformerTypeRepository : Repository<PerformerType>, IRepository<PerformerType>
    {
        public PerformerTypeRepository()
        {
            SetFileName("PerformerTypeData.json");
        }
        public PerformerType? Create(PerformerType instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance != null) { return null; }

            var instances = GetAll();
            instance.Id = Utils.GenerateId();
            instances.Add(instance);
            Save(instances);

            return instance;
        }

        public PerformerType? Delete(PerformerType instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(instance);
            Save(instances);

            return instance;
        }

        public PerformerType? Get(PerformerType instance)
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

        public List<PerformerType> GetAll()
        {
            return Load();
        }

        public PerformerType? Update(PerformerType instance)
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
