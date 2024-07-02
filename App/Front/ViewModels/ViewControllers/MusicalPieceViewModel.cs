﻿using App.Back.Domain;
using App.Back.Service;
using App.Front.ViewModels.DTO;

namespace App.Front.ViewModels.ViewControllers
{
    public class MusicalPieceViewModel
    {
        private MusicalPieceService _musicalPerformanceService;
        private PictureService _pictureService;
        private MusicalGenreService _musicalGenreService;
        public MusicalPieceViewModel() 
        {
            _musicalPerformanceService = new MusicalPieceService();
            _pictureService = new PictureService();
            _musicalGenreService = new MusicalGenreService();
        }

        public Picture? CreatePicture(Picture newPicture)
        {
            return _pictureService.Create(newPicture);
        }

        public MusicPieceDTO? CreateMusicPiece(MusicPieceDTO newMusicPiece)
        {
            newMusicPiece.ProfilePicture = _pictureService.GetDefaultProfilePicture();
            return _musicalPerformanceService.Create(newMusicPiece);
        }

        public List<MusicalGenreDTO> GetAllMusicalGenre()
        {
            return _musicalGenreService.GetAll();
        }

        public MusicalGenreDTO GetByGenreName(string name)
        {
            var genre = _musicalGenreService.GetByName(name);
            if (genre != null)
            {
                return genre;
            }
            return null;
        }


    }
}
