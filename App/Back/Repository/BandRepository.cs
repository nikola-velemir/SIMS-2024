using App.Back.Domain;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;
using App.Back.Utilities;

namespace App.Back.Repository
{
    public class BandRepository : Repository<Band>, IRepository<Band>
    {
        public BandRepository()
        {
            SetFileName("BandData.json");
        }
        public Band? Create(Band newBand)
        {
            var instances = Load();
            newBand.Id = Utils.GenerateId();
            instances.Add(newBand);
            Save(instances);

            return newBand;
        }

        public Band? Delete(Band instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(instance);
            Save(instances);

            return instance;
        }

        public Band? Get(Band instance)
        {
            foreach (var band in GetAll())
            {
                if (band.Id == instance.Id)
                {
                    return band;
                }
            }
            return null;
        }

        public List<Band> GetAll()
        {
            return Load();
        }

        public Band? Update(Band instance)
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
