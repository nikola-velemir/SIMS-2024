using App.Back.Domain;
using App.Back.Repository;
using App.Front.ViewModels.Presentation;

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
        public List<MusicalPiece> GetAll()
        {
            return _musicalPerformanceRepository.GetAll();
        }

        internal MusicalPiece? GetById(int id)
        {
            var instances = GetAll();
            foreach (var p in instances) { 
                if(p.Id == id)
                {
                    return p;
                }
            }
            return null;
        }
    }
}
