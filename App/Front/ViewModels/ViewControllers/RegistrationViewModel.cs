using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Back.Domain.Osobe;
using App.Back.Service;
using App.Front.ViewModels.DTO;

namespace App.Front.ViewModels.ViewControllers
{
    public class RegistrationViewModel
    {
        private PersonService _personService;

        public RegistrationViewModel() {
            _personService = new PersonService();
        }

        public Person Create(PersonDTO personDTO)
        {
            return _personService.Create(personDTO.ToPerson());
        }

        public Person Delete(PersonDTO personDTO)
        {
            return _personService.Delete(personDTO.ToPerson());
        }

        public Person? Get(PersonDTO personDTO)
        {
            return _personService.Get(personDTO.ToPerson());
        }

        public List<Person> GetAll()
        {
            return _personService.GetAll();
        }

        public Person? Update(PersonDTO personDTO)
        {
            return _personService.Update(personDTO.ToPerson());
        }

    }
}
