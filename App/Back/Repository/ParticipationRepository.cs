using App.Back.Domain;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;

namespace App.Back.Repository
{
    public class ParticipationRepository : Repository<Participation>, IRepository<Participation>
    {
        public ParticipationRepository() {
            SetFileName("ParticipationData.json");
        }
        public Participation? Create(Participation instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance != null) { return null; }

            var instances = GetAll();
            instances.Add(instance);
            Save(instances);

            return instance;
        }

        public Participation? Delete(Participation instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(instance);
            Save(instances);

            return instance;
        }

        public Participation? Get(Participation instance)
        {
            foreach (var izvodjac in GetAll())
            {
                if (izvodjac.PerformerId == instance.PerformerId &&
                    izvodjac.PieceId == instance.PieceId && izvodjac.PerformerTypeId == izvodjac.PerformerTypeId)
                {
                    return izvodjac;
                }
            }
            return null;
        }

        public List<Participation> GetAll()
        {
            return Load();
        }

        public Participation? Update(Participation instance)
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
