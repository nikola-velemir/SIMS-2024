using App.Back.Domain;
using App.Back.Repository;

namespace App.Back.Service
{
    public class BandService
    {
        private BandRepository _bandRepository;
        public BandService()
        {
            _bandRepository = new BandRepository();
        }

        public List<Band> GetAll()
        {
            return _bandRepository.GetAll();
        }
        public Band? GetById(int id)
        {
            foreach (var band in _bandRepository.GetAll())
            {
                if (band.Id == id) return band;
            }
            return null;

        }
        public Band? Create(Band newBand)
        {
            return _bandRepository.Create(newBand);
        }

        public Band? GetByName(string name)
        {
            foreach (Band band in _bandRepository.GetAll())
            {
                if (band.Name == name)
                {
                    return band;
                }
            }
            return null;
        }

    }
}
