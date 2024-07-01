using App.Back.Domain;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;
using App.Back.Utilities;

namespace App.Back.Repository
{
    public class MusicalPieceRepository : Repository<MusicalPiece>, IRepository<MusicalPiece>
    {
        public MusicalPieceRepository() 
        {
            SetFileName("MusicalPieceData.json");
        }   
        public MusicalPiece? Create(MusicalPiece newMusicalPerformance)
        {
            var instances = Load();
            newMusicalPerformance.Id = Utils.GenerateId();
            instances.Add(newMusicalPerformance);
            Save(instances);

            return newMusicalPerformance;
        }

        public MusicalPiece? Delete(MusicalPiece instance)
        {
            throw new NotImplementedException();
        }

        public MusicalPiece? Get(MusicalPiece instance)
        {
            throw new NotImplementedException();
        }

        public List<MusicalPiece> GetAll()
        {
           return Load();
        }

        public MusicalPiece? Update(MusicalPiece instance)
        {
            throw new NotImplementedException();
        }
    }
}
