using App.Back.Domain;
using App.Back.Repository;

namespace App.Back.Service
{

    public class MusicalPerformanceService 
    {
        private MusicalPerformanceRepository _musicalPerformanceRepository;
        public MusicalPerformanceService() 
        {
            _musicalPerformanceRepository = new MusicalPerformanceRepository();
        }
        public MusicalPiece? Create(MusicalPiece newMusicalPerformance)
        {
            return _musicalPerformanceRepository.Create(newMusicalPerformance);
        }
    }
}
