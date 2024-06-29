using App.Back.Domain;
using App.Back.Domain.Connectors;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;
using App.Back.Utilities;

namespace App.Back.Repository
{
    public class TipUcesnikaUcesceConnectorRepository : Repository<TipUcesnikaUcesceConnector>, IRepository<TipUcesnikaUcesceConnector>
    {
        public TipUcesnikaUcesceConnectorRepository()
        {
            SetFileName("TipUcesnikaUcesceConnectors.json");
        }
        public TipUcesnikaUcesceConnector? Create(TipUcesnikaUcesceConnector instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance != null) { return null; }

            var instances = GetAll();
            instances.Add(instance);
            Save(instances);

            return instance;
        }

        public TipUcesnikaUcesceConnector? Delete(TipUcesnikaUcesceConnector instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(instance);
            Save(instances);

            return instance;
        }

        public TipUcesnikaUcesceConnector? Get(TipUcesnikaUcesceConnector instance)
        {
            foreach (var izvodjac in GetAll())
            {
                if (izvodjac.IdTipUcesnika == instance.IdTipUcesnika &&
                    izvodjac.IdUcesce == instance.IdUcesce)
                {
                    return izvodjac;
                }
            }
            return null;
        }

        public List<TipUcesnikaUcesceConnector> GetAll()
        {
            return Load();
        }

        public TipUcesnikaUcesceConnector? Update(TipUcesnikaUcesceConnector instance)
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
