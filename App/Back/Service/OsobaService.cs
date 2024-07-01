using App.Back.Domain.Osobe;
using App.Back.Repository;

namespace App.Back.Service
{
    public class OsobaService
    {
        private OsobaRepository _repository;

        public OsobaService()
        {
            _repository = new OsobaRepository();
        }

        public Osoba? Create(Osoba instance)
        {
            return _repository.Create(instance);
        }

        public Osoba? Delete(Osoba instance)
        {
            return _repository.Delete(instance);
        }

        public Osoba? Get(Osoba instance)
        {
            return _repository.Get(instance);
        }

        public List<Osoba> GetAll()
        {
            return _repository.GetAll();
        }

        public Osoba? Update(Osoba instance)
        {
            return _repository.Update(instance);
        }

    }
}
