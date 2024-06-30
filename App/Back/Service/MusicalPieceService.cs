using App.Back.Domain;
using App.Back.Repository;

namespace App.Back.Service
{

    public class MusicalPieceService 
    {
        private MusicalPieceRepository _musicalPerformanceRepository;
        public MusicalPieceService() 
        {
            _musicalPerformanceRepository = new MusicalPieceRepository();
        }
        public MusicalPiece? Create(MusicalPiece newMusicalPerformance)
        {
            return _musicalPerformanceRepository.Create(newMusicalPerformance);
        }
    }
}
