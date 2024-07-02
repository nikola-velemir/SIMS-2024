using App.Back.Domain;
using App.Back.Repository;
using App.Front.ViewModels.DTO;
namespace App.Back.Service
{

    public class MusicalPieceService
    {
        private MusicalPieceRepository _musicalPieceRepository;
        private PictureService _pictureService;
        private MusicalGenreService _musicalGenreService;
        public MusicalPieceService()
        {
            _musicalPieceRepository = new MusicalPieceRepository();
            _pictureService = new PictureService();
            _musicalGenreService = new MusicalGenreService();
        }
        public MusicPieceDTO? Create(MusicPieceDTO newMusicalPerformance)
        {
            var musicPiece = _musicalPieceRepository.Create(newMusicalPerformance.ToMusicPiece());
            var musicPieceDTO = new MusicPieceDTO();
            musicPieceDTO.MusicalGenre = _musicalGenreService.GetById(musicPiece.MusicalGenreId).ToMusicGenre();
            var pictures = new List<Picture>();
            foreach (var pictureId in musicPiece.Pictures)
            {
                pictures.Add(_pictureService.GetById(pictureId));
            }
            musicPieceDTO.Pictures = pictures;
            return musicPieceDTO;
        }
        public List<MusicPieceDTO> GetAll()
        {
            var musicPieces = _musicalPieceRepository.GetAll();
            var musicalPieceDTOs = new List<MusicPieceDTO>();
            foreach(var musicPiece in musicPieces)
            {
                var musicalPieceDTO = new MusicPieceDTO(musicPiece);
                var pictures = new List<Picture>();
                foreach(var pictureId in musicPiece.Pictures)
                {
                    pictures.Add(_pictureService.GetById(pictureId));
                }
                musicalPieceDTO.Pictures = pictures;
                musicalPieceDTO.ProfilePicture = _pictureService.GetById(musicPiece.ProfileImageId);
                musicalPieceDTO.MusicalGenre = _musicalGenreService.GetById(musicPiece.MusicalGenreId).ToMusicGenre();
                musicalPieceDTOs.Add(musicalPieceDTO);
            }
            return musicalPieceDTOs;
        }

        public void Delete(MusicPieceDTO musicPieceDTO)
        {
            _musicalPieceRepository.Delete(musicPieceDTO.ToMusicPiece());
        }

        internal MusicPieceDTO? GetById(int id)
        {
            foreach (var p in GetAll()) { 
                if(p.Id == id)
                {
                    return p;
                }
            }
            return null;
        }
    }
}
