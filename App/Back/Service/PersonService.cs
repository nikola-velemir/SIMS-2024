using App.Back.Domain.Osobe;
using App.Back.Repository;

namespace App.Back.Service
{
    public class PersonService
    {
        private PersonRepository _repository;

        public PersonService()
        {
            _repository = new PersonRepository();
        }

        public Person? Create(Person instance)
        {
            return _repository.Create(instance);
        }

        public Person? Delete(Person instance)
        {
            return _repository.Delete(instance);
        }

        public Person? Get(Person instance)
        {
            return _repository.Get(instance);
        }

        public List<Person> GetAll()
        {
            return _repository.GetAll();
        }

        public Person? Update(Person instance)
        {
            return _repository.Update(instance);
        }

    }
}
