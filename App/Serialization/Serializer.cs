using App.Serialization.Interface;
using App.Serialization.Strategy;
using System.IO;

namespace App.Serialization
{
    public class Serializer
    {

        private ISerialization _strategy;
        public Serializer()
        {
            //_strategy = ConfigService.GetSerializationStrategy();   
            _strategy = new JSONSerialization();
        }
        public void HandleFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }
        public G? FromFile<G>(string fileName)
        {
            HandleFile(fileName);
            string jsonString = File.ReadAllText(fileName);
            return _strategy.Deserialize<G>(jsonString);
        }
        public void ToFile<G>(G objects, string fileName)
        {
            HandleFile(fileName);
            string serializedObjects = _strategy.Serialize(objects);
            var streamWriter = new StreamWriter(fileName);
            streamWriter.Write(serializedObjects);
            streamWriter.Close();
        }
    }
}