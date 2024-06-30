using App.Back.Domain;
using App.Back.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Back.Service
{
    
    public class MusicalPerformanceService
    {
        private MusicalPerformanceRepository _musicalPerformanceRepository;
        public MusicalPerformanceService() 
        {
            _musicalPerformanceRepository = new MusicalPerformanceRepository();
        }
        public MusicalPerformance? Create(MusicalPerformance newMusicalPerformance)
        {
            return _musicalPerformanceRepository.Create(newMusicalPerformance);
        }
    }
}
