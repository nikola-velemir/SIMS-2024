using App.Back.Domain;
using App.Back.Domain.Osobe;
using App.Back.Repository;

namespace App.Back.Service
{
    public class PerformerService
    {
        private PerformerRepository _repository;
        public PerformerService()
        {
            _repository = new PerformerRepository();
        }
        public Performer? Get(Performer instance)
        {
            return _repository.Get(instance);
        }
        public Performer? Create(Performer instance)
        {
            return _repository.Create(instance);
        }
        public List<Performer> GetAll()
        {
            return _repository.GetAll();
        }
        public Performer? GetById(int id)
        {
            var instances = GetAll();
            foreach (var instance in instances)
            {
                if (instance.Id == id) return instance;
            }
            return null;
        }
    }
}
