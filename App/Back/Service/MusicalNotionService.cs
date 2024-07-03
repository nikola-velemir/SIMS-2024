using App.Back.Domain;

namespace App.Back.Service
{
    public class MusicalNotionService
    {
        private MusicalPieceService _pieceService;
        private PerformanceService _performanceService;

        public MusicalNotionService()
        {
            _pieceService = new MusicalPieceService();
            _performanceService = new PerformanceService();
        }

        public List<MusicalNotion> GetAll()
        {
            var instances = new List<MusicalNotion>();
            foreach (var n in _pieceService.GetAll())
            {
                instances.Add(n.ToMusicPiece());
            }
            foreach (var n in _performanceService.GetAll())
            {
                instances.Add(n);
            }
            return instances; 
        }
    }
}
