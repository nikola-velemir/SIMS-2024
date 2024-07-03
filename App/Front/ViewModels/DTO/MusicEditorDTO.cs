using App.Back.Domain;
using App.Back.Domain.Osobe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Front.ViewModels.DTO
{
    public class MusicEditorDTO: INotifyPropertyChanged, IDataErrorInfo
    {

        public PersonDTO Person {  get; set; }
        public UserAccountDTO UserAccount { get; set; }
        private List<MusicalGenreDTO> genres;
        public List<MusicalGenreDTO> Genres 
        {
            get { return genres; }
            set
            {
                if(value != null)
                {
                    genres = value;
                    OnPropertyChanged(nameof(Genres));
                }
            }
        }
        public string AccountStatus { get; set; }
        public bool IsValid
        {
            get
            {
                return Person.IsValid && UserAccount.IsValid && Genres.Count > 0;
            }
        }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                
                return null;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public MusicEditorDTO() 
        { 
            Person = new PersonDTO();
            UserAccount = new UserAccountDTO();
            Person.Role = Role.Editor;
            UserAccount.AccountType = AccountType.Editor;
            UserAccount.Active = true;
            Genres = new List<MusicalGenreDTO>();
        }

        public MusicEditorDTO(MusicEditorDTO musicEditor) 
        {
            Person = musicEditor.Person;
            UserAccount = musicEditor.UserAccount;
            Genres = musicEditor.Genres;
            AccountStatus = musicEditor.AccountStatus;
        }

        public MusicEditorDTO(PersonDTO person, UserAccountDTO userAccount, List<MusicalGenreDTO> genres)
        {
            Person = person;
            UserAccount = userAccount;
            AccountStatus = UserAccount.Active ? "Active" : "Deactive";
            Genres = genres;
        }

        private List<int> GetGenreIds()
        {
            var ids = new List<int>();
            foreach(var genre in Genres)
            {
                ids.Add(genre.Id);
            }
            return ids;
        }

        public MusicEditor ToMusicEditor()
        {
            return new MusicEditor(GetGenreIds(), Person.Id, UserAccount.PersonId);
        }

        public override bool Equals(object? obj)
        {
            bool isObj = obj is MusicEditorDTO;
            if (isObj)
            {
                var other = obj as MusicEditorDTO;
                return other.Person.Id == this.Person.Id && other.UserAccount.Id == this.UserAccount.Id;
            }
            return false;
            
        }
    }
}
