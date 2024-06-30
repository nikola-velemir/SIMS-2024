using App.Back.Domain;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;
using App.Back.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Back.Repository
{
    public class MusicalPerformanceRepository : Repository<MusicalPerformance>, IRepository<MusicalPerformance>
    {
        public MusicalPerformanceRepository() 
        {
            SetFileName("MusicalPerformanceData.json");
        }   
        public MusicalPerformance? Create(MusicalPerformance newMusicalPerformance)
        {
            var instances = Load();
            newMusicalPerformance.Id = Utils.GenerateId();
            instances.Add(newMusicalPerformance);
            Save(instances);

            return newMusicalPerformance;
        }

        public MusicalPerformance? Delete(MusicalPerformance instance)
        {
            throw new NotImplementedException();
        }

        public MusicalPerformance? Get(MusicalPerformance instance)
        {
            throw new NotImplementedException();
        }

        public List<MusicalPerformance> GetAll()
        {
            throw new NotImplementedException();
        }

        public MusicalPerformance? Update(MusicalPerformance instance)
        {
            throw new NotImplementedException();
        }
    }
}
