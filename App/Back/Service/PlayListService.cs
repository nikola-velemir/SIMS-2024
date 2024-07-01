using App.Back.Domain;
using App.Back.Repository;
using App.Back.Utilities;

namespace App.Back.Service
{
    public class PlayListService
    {
        private PlayListRepository _repository;
        public PlayListService()
        {
            _repository = new PlayListRepository();
        }

        public List<PlayList> GetAll()
        {
            return _repository.GetAll();
        }
        public List<PlayList> GetByUserId(int id)
        {
            return _repository.GetByUserId(id);
        }
        public PlayList? Create(PlayList item)
        {
            item.Id = Utils.GenerateId();
            return _repository.Create(item);
        }
    }
}
