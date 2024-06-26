using App.Back.Serialization;

namespace App.Back.Repository.Base
{
    public class Repository<Z> where Z : new()
    {
        protected string _fileName = @"../../../../App/Back/Data/{0}";
        protected readonly Serializer _serializer = new();
        protected List<Z> _instances;

        protected void SetFileName(string fileName)
        {
            _fileName = string.Format(_fileName, fileName);

        }
        protected void Load()
        {
            _instances = _serializer.FromFile<List<Z>>(_fileName)
                ?? new List<Z>();

        }
        protected void Save()
        {
            _serializer.ToFile(_instances, _fileName);
        }
    }
}
