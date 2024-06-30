using App.Back.Domain;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;
using App.Back.Utilities;

namespace App.Back.Repository
{
    public class PictureRepository : Repository<Picture>, IRepository<Picture>
    {
        public PictureRepository()
        {
            SetFileName("PictureData.json");
        }
        public Picture? Create(Picture newPicture)
        {
            var instances = Load();
            newPicture.Id = Utils.GenerateId();
            instances.Add(newPicture);
            Save(instances);

            return newPicture;
        }

        public Picture? Delete(Picture instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(instance);
            Save(instances);

            return instance;
        }

        public Picture? Get(Picture instance)
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

        public List<Picture> GetAll()
        {
            return Load();
        }

        public Picture? Update(Picture instance)
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
