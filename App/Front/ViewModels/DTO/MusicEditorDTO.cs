using App.Back.Domain;
using App.Back.Domain.Osobe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Front.ViewModels.DTO
{
    public class MusicEditorDTO
    {
        public PersonDTO Person { get; set; }
        public UserAccountDTO UserAccount { get; set; }
        public List<MusicGenre> Genres { get; set; }
        public string AccountStatus { get; set; }
        public MusicEditorDTO() { }

        public MusicEditorDTO(PersonDTO person, UserAccountDTO userAccount, List<MusicGenre> genres)
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
            return new MusicEditor(Person.Id, Person.FirstName, Person.LastName, Person.JMBG, DateOnly.FromDateTime(Person.BirthDate), Person.Gender, UserAccount.Id, GetGenreIds());
        }
    }
}
