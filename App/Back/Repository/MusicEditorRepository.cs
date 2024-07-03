using App.Back.Domain.Osobe;
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
    public class MusicEditorRepository : Repository<MusicEditor>, IRepository<MusicEditor>
    {
        public MusicEditorRepository()
        {
            SetFileName("MusicEditorData.json");
        }

        public int GetLastId()
        {
            var jArray = Load();
            if (jArray.Count == 0) { return 0; }
            return jArray[jArray.Count - 1].Id;
        }
        public MusicEditor? Create(MusicEditor instance)
        {
            var instances = Load();
            instance.Id = GetLastId() + 1;
            instances.Add(instance);
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
                if (musicEditor.AccountId == instance.AccountId && musicEditor.PersonId == instance.PersonId)
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

        public List<int> GetGenreList(int personId, int accountId)
        {
            foreach(var musicEditor in GetAll())
            {
                if(musicEditor.PersonId == personId && musicEditor.AccountId == accountId)
                {
                    return musicEditor.Genres;
                }
            }
            return null;
        }
    }
}
