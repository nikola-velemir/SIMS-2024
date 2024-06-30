using App.Back.Domain;
using App.Back.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
