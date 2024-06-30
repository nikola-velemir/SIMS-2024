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

        public Performer? Create(Performer instance)
        {
            return _repository.Create(instance);
        }

        public Performer? Delete(Performer instance)
        {
            return _repository.Delete(instance);
        }

        public Performer? Get(Performer instance)
        {
            return _repository.Get(instance);
        }

        public List<Performer> GetAll()
        {
            return _repository.GetAll();
        }

        public Performer? Update(Performer instance)
        {
            return _repository.Update(instance);
        }
    }
}
