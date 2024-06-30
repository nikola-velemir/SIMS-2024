using App.Back.Domain;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;

namespace App.Back.Repository
{
    public class PerformanceRepository : Repository<Performance>, IRepository<Performance>
    {
        public PerformanceRepository()
        {
            SetFileName("PerformanceData.json");
        }

        public Performance? Create(Performance instance)
        {
            throw new NotImplementedException();
        }

        public Performance? Delete(Performance instance)
        {
            throw new NotImplementedException();
        }

        public Performance? Get(Performance instance)
        {
            throw new NotImplementedException();
        }

        public List<Performance> GetAll()
        {
            throw new NotImplementedException();
        }

        public Performance? Update(Performance instance)
        {
            throw new NotImplementedException();
        }
    }
}
