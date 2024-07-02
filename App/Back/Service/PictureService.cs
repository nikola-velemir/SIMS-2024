using App.Back.Domain;
using App.Back.Repository;

namespace App.Back.Service
{
    public class PictureService
    {
        private PictureRepository _pictureRepository;
        public PictureService()
        {
            _pictureRepository = new PictureRepository();
        }

        public Picture? Create(Picture newPicture)
        {
            return _pictureRepository.Create(newPicture);
        }
        public Picture? Delete(Picture instance)
        {
            return _pictureRepository.Delete(instance);
        }

        public Picture? Get(Picture instance)
        {
            return _pictureRepository.Get(instance);
        }

        public Picture? GetById(int instanceId)
        {
            var pictures = GetAll();
            foreach (var picture in pictures)
            {
                if (picture.Id == instanceId) return picture;
            }
            return null;
        }

        public List<Picture> GetAll()
        {
            return _pictureRepository.GetAll();
        }

        public Picture? Update(Picture instance)
        {
            return _pictureRepository.Update(instance);
        }

        public Picture GetDefaultProfilePicture()
        {
            return _pictureRepository.GetById(75484);
        }
    }
}
