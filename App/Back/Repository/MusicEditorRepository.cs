using App.Back.Domain.Osobe;
using App.Back.Repository.Base;
using App.Back.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Back.Repository
{
    public class MusicEditorRepository : Repository<MusicEditor>, IRepository<MusicEditor>
    {
        public MusicEditorRepository()
        {
        }

        public MusicEditor? Create(MusicEditor instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(instance);
            Save(instances);

            return instance;
        }

        public MusicEditor? Delete(MusicEditor instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(instance);
            Save(instances);

            return instance;
        }

        public MusicEditor? Get(MusicEditor instance)
        {
            foreach (var musicEditor in GetAll())
            {
                if (musicEditor.Id == instance.Id)
                {
                    return musicEditor;
                }
            }
            return null;
        }

        public List<MusicEditor> GetAll()
        {
            return Load();
        }

        public MusicEditor? Update(MusicEditor instance)
        {
            var fetchedInstance = Get(instance);

            if (fetchedInstance == null) { return null; }

            var instances = Load();
            instances.Remove(fetchedInstance);
            instances.Add(instance);
            Save(instances);

            return instance;
        }
    }
}
