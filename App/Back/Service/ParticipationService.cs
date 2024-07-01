using App.Back.Domain;
using App.Back.Domain.Osobe;
using App.Back.Repository;

namespace App.Back.Service
{
    public class ParticipationService
    {
        private ParticipationRepository _repository;
        private PerformerService _performerService;
        public ParticipationService()
        {
            _repository = new();
            _performerService = new();
        }
        public Participation? Get(Participation instance)
        {
            return _repository.Get(instance);
        }
        public List<Participation> GetAll()
        {
            return _repository.GetAll();
        }
        public List<Participation> GetByPieceId(int id)
        {
            List<Participation> participations = new List<Participation>();
            var instaces = GetAll();
            foreach (var i in instaces)
            {
                if (i.PieceId == id)
                {
                    participations.Add(i);
                }
            }
            return participations;
        }
        public List<Performer> GetPerformersByPieceId(int id)
        {
            var instance = GetByPieceId(id);
            List<Performer> performers = new();

            foreach (var i in instance)
            {
                var performer = _performerService.GetById(i.PerformerId);
                if(performer == null) { continue; }
                performers.Add(performer);
            }

            return performers;
        }

    }
}
