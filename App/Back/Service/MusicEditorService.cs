using App.Back.Domain.Osobe;
using App.Back.Repository;
using App.Front.ViewModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Back.Service
{
    public class MusicEditorService
    {
        private MusicEditorRepository _musicEditorRepository;
        private UserAccountService _userAccountService;
        private PersonService _personService;
        private MusicalGenreService _musicalGenreService;

        public MusicEditorService()
        {
            _musicEditorRepository = new MusicEditorRepository();
            _userAccountService = new UserAccountService();
            _personService = new PersonService();
            _musicalGenreService = new MusicalGenreService();
        }

        private MusicEditorDTO Fill(MusicEditor musicEditor)
        {
            var musicEditorDTO = new MusicEditorDTO();
            musicEditorDTO.Person = new PersonDTO(_personService.GetById(musicEditor.PersonId));
            musicEditorDTO.UserAccount = new UserAccountDTO(_userAccountService.GetById(musicEditor.AccountId));
            musicEditorDTO.Genres = _musicalGenreService.GetByIds(musicEditor.Genres);
            return musicEditorDTO;
        }

        public MusicEditorDTO Create(MusicEditorDTO newMusicEditorDTO)
        {
            newMusicEditorDTO.Person.Role = Domain.Role.Editor;
            newMusicEditorDTO.UserAccount.AccountType = Domain.AccountType.Editor;
            var person = _personService.Create(newMusicEditorDTO.Person.ToPerson());
            newMusicEditorDTO.Person.Id = person.Id;
            newMusicEditorDTO.UserAccount.PersonId = person.Id;
            var userAccount = _userAccountService.Create(newMusicEditorDTO.UserAccount.ToUserAccount());
            newMusicEditorDTO.UserAccount.Id = userAccount.Id;
            var musicEditor = _musicEditorRepository.Create(newMusicEditorDTO.ToMusicEditor());
            var musicEditorDTO = Fill(musicEditor);
            return musicEditorDTO;
        }

        public MusicEditorDTO? Delete(MusicEditorDTO oldMusicEditor)
        {
            oldMusicEditor.UserAccount.Active = false;
            _userAccountService.Update(oldMusicEditor.UserAccount.ToUserAccount());
            var musicEditor = _musicEditorRepository.Delete(oldMusicEditor.ToMusicEditor());
            return null;
        }

        public MusicEditorDTO Update(MusicEditorDTO newMusicEditor)
        {
            _personService.Update(newMusicEditor.Person.ToPerson());
            _userAccountService.Update(newMusicEditor.UserAccount.ToUserAccount());
            var musicEditor =_musicEditorRepository.Update(newMusicEditor.ToMusicEditor());
            var musicEditorDTO = Fill(musicEditor);
            return musicEditorDTO;
        }
        public List<MusicalGenreDTO> GetGenres(int personId, int id)
        {
            var genres = new List<MusicalGenreDTO>();
            foreach(int genreId in _musicEditorRepository.GetGenreList(personId, id))
            {
                genres.Add(_musicalGenreService.GetById(genreId));
            }

            return genres;
        }
    }
}
