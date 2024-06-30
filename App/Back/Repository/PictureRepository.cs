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
            throw new NotImplementedException();
        }

        public Picture? Get(Picture instance)
        {
            throw new NotImplementedException();
        }

        public List<Picture> GetAll()
        {
            throw new NotImplementedException();
        }

        public Picture? Update(Picture instance)
        {
            throw new NotImplementedException();
        }
    }
}
