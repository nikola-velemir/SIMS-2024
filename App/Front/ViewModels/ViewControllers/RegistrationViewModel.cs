using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Back.Domain;
using App.Back.Domain.Osobe;
using App.Back.Service;
using App.Front.ViewModels.DTO;

namespace App.Front.ViewModels.ViewControllers
{
    public class RegistrationViewModel
    {
        private PersonService _personService;
        private UserAccountService _userAccountService;

        public RegistrationViewModel() {
            _personService = new PersonService();
            _userAccountService = new UserAccountService();
        }

        public PersonDTO? Create(PersonDTO personDTO)
        {
            Person? person = _personService.Create(personDTO.ToPerson());
            if(person == null){ return null; }
            return new PersonDTO(person);
        }

        public PersonDTO? Delete(PersonDTO personDTO)
        {
            Person? person = _personService.Delete(personDTO.ToPerson());
            if(person == null) { return null; }
            return new PersonDTO(person);
        }

        public PersonDTO? Get(PersonDTO personDTO)
        {
            Person? person = _personService.Get(personDTO.ToPerson());
            if(person == null) { return null; }
            return new PersonDTO(person);
        }

        public List<PersonDTO> GetAll()
        {
            List<PersonDTO> personDTOs = new List<PersonDTO>();
            foreach(var person in  _personService.GetAll())
            {
                personDTOs.Add(new PersonDTO(person));
            }
            return personDTOs;
        }

        public PersonDTO? Update(PersonDTO personDTO)
        {
            Person? person = _personService.Update(personDTO.ToPerson());
            if(person == null) { return null; }
            return new PersonDTO(person);
        }

        public UserAccountDTO? Create(UserAccountDTO userAccountDTO)
        {
            UserAccount? userAccount = _userAccountService.Create(userAccountDTO.ToUserAccount());
            if(userAccount == null) { return null; }
            return new UserAccountDTO(userAccount);
        }

        public bool CanUserRegistrate(UserAccountDTO userAccountDTO)
        {
            return _userAccountService.CanUserRegistrate(userAccountDTO.ToUserAccount());
        }

        public bool CheckJMBG(PersonDTO personDTO)
        {
            return _personService.CheckJMBG(personDTO.ToPerson());
        }

    }
}
