using App.Back.Domain;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;
using App.Back.Utilities;

namespace App.Back.Repository
{
    public class UserAccountRepository : Repository<UserAccount>, IRepository<UserAccount>
    {
        public UserAccountRepository()
        {
            SetFileName("NalogData.json");
        }
        public UserAccount? Create(UserAccount instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance != null) { return null; }

            var instances = Load();
            instance.Id = Utils.GenerateId();
            instances.Add(instance);
            Save(instances);

            return instance;
        }

        public UserAccount? Delete(UserAccount instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(instance);
            Save(instances);

            return instance;
        }

        public UserAccount? Get(UserAccount instance)
        {
            foreach (var nalog in GetAll())
            {
                if (nalog.Id == instance.Id)
                {
                    return nalog;
                }
            }
            return null;
        }

        public List<UserAccount> GetAll()
        {
            return Load();
        }

        public UserAccount? Update(UserAccount instance)
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
