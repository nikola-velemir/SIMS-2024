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
    public class PersonViewModel
    {
        private OsobaService _personService;

        public PersonViewModel() {
            _personService = new OsobaService();
        }

        public Osoba Create(PersonDTO personDTO)
        {
            return _personService.Create(personDTO.ToPerson());
        }

        public Osoba Delete(PersonDTO personDTO)
        {
            return _personService.Delete(personDTO.ToPerson());
        }

        public Osoba? Get(PersonDTO personDTO)
        {
            return _personService.Get(personDTO.ToPerson());
        }

        public List<Osoba> GetAll()
        {
            return _personService.GetAll();
        }

        public Osoba? Update(PersonDTO personDTO)
        {
            return _personService.Update(personDTO.ToPerson());
        }

    }
}
