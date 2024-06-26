using App.Back.Domain;
using App.Back.Repository;

namespace App.Back.Service
{
    public class NalogService
    {
        private NalogRepository _repository;

        public NalogService()
        {
            _repository = new NalogRepository();
        }

        public Nalog? Create(Nalog instance)
        {
            return _repository.Create(instance);
        }

        public Nalog? Delete(Nalog instance)
        {
            return _repository.Delete(instance);
        }

        public Nalog? Get(Nalog instance)
        {
            return _repository.Get(instance);
        }

        public List<Nalog> GetAll()
        {
            return _repository.GetAll();
        }

        public Nalog? Update(Nalog instance)
        {
            return _repository.Update(instance);
        }

        public Nalog? GeyByKorisnickoAndLozinka(string korisnickoIme, string lozinka)
        {
            foreach (var nalog in _repository.GetAll())
            {
                if (nalog.KorisnickoIme == korisnickoIme && nalog.Lozinka == lozinka)
                {
                    return nalog;
                }
            }
            return null;
        }
    }
}
