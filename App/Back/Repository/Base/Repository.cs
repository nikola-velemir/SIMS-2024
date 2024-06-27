using App.Back.Serialization;

namespace App.Back.Repository.Base
{
    public class Repository<Z> where Z : new()
    {
        protected string _fileName = @"../../../../App/Back/Data/{0}";
        protected readonly Serializer _serializer = new();

        protected void SetFileName(string fileName)
        {
            _fileName = string.Format(_fileName, fileName);

        }
        protected List<Z> Load()
        {
            return _serializer.FromFile<List<Z>>(_fileName)
                ?? new List<Z>();

        }
        protected void Save(List<Z> instances)
        {
            _serializer.ToFile(instances, _fileName);
        }
    }
}
