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

        public MusicEditorService()
        {
            _musicEditorRepository = new MusicEditorRepository();
            _userAccountService = new UserAccountService();
            _personService = new PersonService();
        }

        public MusicEditorDTO Create(MusicEditorDTO newMusicEditorDTO)
        {
            var musicEditor = _musicEditorRepository.Create(newMusicEditorDTO.ToMusicEditor());
            var musicEditorDTO = new MusicEditorDTO();
            return new MusicEditorDTO(musicEditor);
        }
    }
}
