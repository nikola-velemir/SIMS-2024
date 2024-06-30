using App.Back.Domain;
using App.Back.Domain.Connectors;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;
using App.Back.Utilities;

namespace App.Back.Repository
{
    public class PerformerTypeParticipationConnectorRepository : Repository<PerformerTypeParticipationConnector>, IRepository<PerformerTypeParticipationConnector>
    {
        public PerformerTypeParticipationConnectorRepository()
        {
            SetFileName("TipUcesnikaUcesceConnectors.json");
        }
        public PerformerTypeParticipationConnector? Create(PerformerTypeParticipationConnector instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance != null) { return null; }

            var instances = GetAll();
            instances.Add(instance);
            Save(instances);

            return instance;
        }

        public PerformerTypeParticipationConnector? Delete(PerformerTypeParticipationConnector instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(instance);
            Save(instances);

            return instance;
        }

        public PerformerTypeParticipationConnector? Get(PerformerTypeParticipationConnector instance)
        {
            foreach (var izvodjac in GetAll())
            {
                if (izvodjac.PerformerTypeId == instance.PerformerTypeId &&
                    izvodjac.PerformanceId == instance.PerformanceId)
                {
                    return izvodjac;
                }
            }
            return null;
        }

        public List<PerformerTypeParticipationConnector> GetAll()
        {
            return Load();
        }

        public PerformerTypeParticipationConnector? Update(PerformerTypeParticipationConnector instance)
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
