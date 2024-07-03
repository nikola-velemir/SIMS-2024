using App.Back.Domain;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;
using App.Back.Utilities;
using Newtonsoft.Json.Linq;

namespace App.Back.Repository
{
    public class UserAccountRepository : Repository<UserAccount>, IRepository<UserAccount>
    {
        public UserAccountRepository()
        {
            SetFileName("UserAccountData.json");
        }
        public UserAccount? Create(UserAccount instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance != null) { return null; }

            var instances = Load();
            instance.Id = GetLastId() + 1;
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

        public int GetLastId()
        {
            var jArray = Load();
            if (jArray.Count == 0) { return 0; }
            return jArray[jArray.Count-1].Id;
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
