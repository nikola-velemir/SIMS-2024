using App.Domain;
using App.Repository;

namespace App.Service
{
    public class IzvodjacService
    {
        private IzvodjacRepository _repository;

        public IzvodjacService()
        {
            _repository = new IzvodjacRepository();
        }

        public Izvodjac? Create(Izvodjac instance)
        {
            return _repository.Create(instance);
        }

        public Izvodjac? Delete(Izvodjac instance)
        {
            return _repository.Delete(instance);
        }

        public Izvodjac? Get(Izvodjac instance)
        {
            return _repository.Get(instance);
        }

        public List<Izvodjac> GetAll()
        {
            return _repository.GetAll();
        }

        public Izvodjac? Update(Izvodjac instance)
        {
            return _repository.Update(instance);
        }
    }
}
