using App.Back.Service;
using App.Front.ViewModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Front.ViewModels.ViewControllers
{
    public class MusicEditorViewModel
    {
        private MusicEditorService _musicEditorService;
        private MusicalGenreService _musicalGenreService;
        public MusicEditorViewModel() 
        {
            _musicEditorService = new MusicEditorService();
            _musicalGenreService = new MusicalGenreService();
        }

        public MusicEditorDTO Create(MusicEditorDTO newMusicEditor) 
        {
            return _musicEditorService.Create(newMusicEditor);
        }

        public MusicEditorDTO Update(MusicEditorDTO newMusicEditor)
        {
            return _musicEditorService.Update(newMusicEditor);
        }

        public MusicEditorDTO Delete(MusicEditorDTO oldMusicEditor)
        {
            return _musicEditorService.Delete(oldMusicEditor);
        }

        public IEnumerable<MusicalGenreDTO>? GetAllGenres()
        {
            return _musicalGenreService.GetAll();
        }
    }
}
