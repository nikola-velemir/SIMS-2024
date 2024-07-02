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

        public bool CheckJMBG(Person person)
        {
            string jmbg = person.JMBG;
            string jmbgDay = jmbg.Substring(0, 2);
            string jmbgMonth = jmbg.Substring(2, 2);
            string jmbgYear = jmbg.Substring(4, 3);
            string birthdate = person.BirthDate.ToString("dd.MM.yyyy");
            string[] partsDate = birthdate.Split(".");
            partsDate[2] = partsDate[2].Substring(1,3);
            if (jmbgDay != partsDate[0] || jmbgMonth != partsDate[1] || jmbgYear != partsDate[2])
            {
                return false;
            }
            return true;

        }

        public Person? GetByAccountId(int id)
        {
            foreach(Person person in _repository.GetAll())
            {
                if(person.AccountId == id)
                {
                    return person;
                }
            }
            return null;
        }
    }
}
