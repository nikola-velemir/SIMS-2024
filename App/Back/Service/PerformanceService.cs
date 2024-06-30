using App.Back.Domain;
using App.Back.Repository;

namespace App.Back.Service
{
    public class PerformanceService
    {
        private PerformanceRepository _repository;
        public PerformanceService()
        {
            _repository = new PerformanceRepository();
        }
        public List<Performance> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
