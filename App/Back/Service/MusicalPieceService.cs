using App.Back.Domain;
using App.Back.Repository;
using App.Front.ViewModels.DTO;
using App.Front.ViewModels.Presentation;

namespace App.Back.Service
{

    public class MusicalPieceService
    {
        private MusicalPieceRepository _musicalPerformanceRepository;
        private PictureService _pictureService;
        public MusicalPieceService()
        {
            _musicalPerformanceRepository = new MusicalPieceRepository();
            _pictureService = new PictureService();
        }
        public MusicPieceDTO? Create(MusicPieceDTO newMusicalPerformance)
        {
            return new MusicPieceDTO(_musicalPerformanceRepository.Create(newMusicalPerformance.ToMusicPiece()));
        }
        public List<MusicPieceDTO> GetAll()
        {
            var musicPieces = _musicalPerformanceRepository.GetAll();
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
                musicalPieceDTOs.Add(musicalPieceDTO);
            }
            return musicalPieceDTOs;
        }
    }
}
