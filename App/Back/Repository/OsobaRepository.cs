using App.Back.Domain;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Back.Repository
{
    public class OsobaRepository : Repository<Osoba>, IRepository<Osoba>
    {
        private List<Osoba> _osobe { get; set; }
        public OsobaRepository()
        {
            SetFileName("OsobaData.json");
            Load();
            _osobe = _instances;

        }
        public Osoba? Create(Osoba instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance != null) { return null; }

            _instances.Add(instance);
            Save();

            return instance;
        }

        public Osoba? Delete(Osoba instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            _instances.Remove(instance);
            Save();

            return instance;
        }

        public Osoba? Get(Osoba instance)
        {
            foreach (var izvodjac in _osobe)
            {
                if (izvodjac.Id == instance.Id)
                {
                    return izvodjac;
                }
            }
            return null;
        }

        public Osoba? Update(Osoba instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            _instances.Remove(fetchedInstance);
            _instances.Add(instance);
            Save();

            return instance;
        }

        public List<Osoba> GetAll()
        {
            return _instances;
        }
    }
}
