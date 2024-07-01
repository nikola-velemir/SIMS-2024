using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Back.Domain;
using App.Back.Domain.Osobe;

namespace App.Front.ViewModels.DTO
{
    public class PersonDTO : INotifyPropertyChanged, IDataErrorInfo
    {
        public int Id { get; set; }

        private string firstName;

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value != firstName)
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        private string lastName;

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value != lastName)
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        private string jmbg;
        public string JMBG
        {
            get
            {
                return jmbg;
            }
            set
            {
                if (value != jmbg)
                {
                    jmbg = value;
                    OnPropertyChanged("JMBG");
                }
            }
        }

        private DateTime birthDate;
        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                if (value != birthDate)
                {
                    birthDate = value;
                    OnPropertyChanged("BirthDate");
                }
            }
        }

        private Genders gender;
        public Genders Gender
        {
            get
            {
                return gender;
            }
            set
            {
                if (value != gender)
                {
                    gender = value;
                    OnPropertyChanged("Gender");
                }
            }
        }

        public int AccountId { get; set; }

        public Role Role { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            
        }

        private readonly string[] _validatedProperties = { "FirstName", "LastName", "JMBG", "BirthDate" };
        public bool IsValid
        {
            get
            {
                foreach (var property in _validatedProperties)
                {
                    if (this[property] != null)
                        return false;
                }

                return true;
            }
        }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (columnName == "FirstName")
                {
                    if (string.IsNullOrEmpty(FirstName))
                    {
                        return "FirstName is required";
                    }
                }
                else if(columnName == "LastName")
                {
                    if (string.IsNullOrEmpty(LastName))
                    {
                        return "LastName is required";
                    }
                }
                else if(columnName == "JMBG")
                {
                    if (string.IsNullOrEmpty(JMBG))
                    {
                        return "JMBG is required";
                    }
                    if(JMBG.Length != 13)
                    {
                        return "JMBG must have 13 numbers";
                    }
                }
                else if(columnName == "BirthDate")
                {
                    if (BirthDate.Date >= DateTime.Now.Date)
                    {
                        return "BirthDate must be in the future";
                    }
                    if(BirthDate.AddYears(18).Date > DateTime.Now.Date)
                    {
                        return "You have to be 18 years old";
                    }
                    if(BirthDate.Year < 1900)
                    {
                        return "Minimum is 1900 year";
                    }
                }
                return null;
            }
        }

        public Person ToPerson()
        {
            return new Person(Id, FirstName, LastName, JMBG, DateOnly.FromDateTime(BirthDate), Gender, AccountId, Role);
        }

        public PersonDTO() { }

        public PersonDTO (Person person)
        {
            Id = person.Id;
            FirstName = person.FirstName;
            LastName = person.LastName;
            JMBG = person.JMBG;
            BirthDate = (person.BirthDate).ToDateTime(TimeOnly.Parse("00:00 AM"));
            Gender = person.Gender;
            AccountId = (int)person.AccountId;
            Role = person.Role;
        }
    }
}
