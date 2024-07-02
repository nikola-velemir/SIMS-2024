using App.Back.Domain.Osobe;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;
using App.Back.Utilities;

namespace App.Back.Repository
{
    public class PersonRepository : Repository<Person>, IRepository<Person>
    {
        public PersonRepository()
        {
            SetFileName("PersonData.json");
        }
        public Person? Create(Person instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance != null) { return null; }

            var instances = GetAll();
            instance.Id = GetLastId() + 1;
            instances.Add(instance);
            Save(instances);

            return instance;
        }

        public Person? Delete(Person instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(instance);
            Save(instances);

            return instance;
        }

        public Person? Get(Person instance)
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

        public Person? Update(Person instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(fetchedInstance);
            instances.Add(instance);
            Save(instances);

            return instance;
        }

        public List<Person> GetAll()
        {
            return Load();
        }

        public int GetLastId()
        {
            var jArray = Load();
            if(jArray.Count == 0) { return 0; }
            return jArray[jArray.Count - 1].Id;
        }
    }
}
