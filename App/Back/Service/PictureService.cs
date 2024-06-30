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
    }
}
