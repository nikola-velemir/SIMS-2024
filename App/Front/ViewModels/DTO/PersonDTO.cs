using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Back.Domain;

namespace App.Front.ViewModels.DTO
{
    class PersonDTO : INotifyPropertyChanged, IDataErrorInfo
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

        private Polovi gender;
        public Polovi Gender
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

        public Uloga Role { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private readonly string[] _validatedProperties = { "FirstName", "LastName", "JMBG", "BirthDate", "Gender" };
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
                    if (FirstName == null)
                    {
                        return "";
                    }
                    if (string.IsNullOrEmpty(FirstName))
                    {
                        return "FirstName is required";
                    }
                }
                else if(columnName == "LastName")
                {
                    if (LastName == null)
                    {
                        return "";
                    }
                    if (string.IsNullOrEmpty(LastName))
                    {
                        return "LastName is required";
                    }
                }
                else if(columnName == "JMBG")
                {
                    if (JMBG == null)
                    {
                        return "";
                    }
                    if (string.IsNullOrEmpty(JMBG))
                    {
                        return "JMBG is required";
                    }
                    if(JMBG.Length != 13)
                    {
                        return "JMBG must have 13 character";
                    }
                }
                else if(columnName == "BirthDate")
                {
                    if (BirthDate == null)
                    {
                        return "";
                    }
                    if (BirthDate.Date >= DateTime.Now.Date)
                    {
                        return "BirthDate must be in the future";
                    }
                    if(BirthDate.Date.AddYears(18) > DateTime.Now.Date)
                    {
                        return "You have toi be 18 years old";
                    }
                }
                return null;
            }
        }
    }
}
