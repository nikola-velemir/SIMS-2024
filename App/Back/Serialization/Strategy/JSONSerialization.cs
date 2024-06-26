using App.Back.Serialization.Interface;
using Newtonsoft.Json;

namespace App.Back.Serialization.Strategy
{
    public class JSONSerialization : ISerialization
    {
        public string Serialize<G>(G? objects)
        {
            if (objects == null) throw new ArgumentNullException();
            return JsonConvert.SerializeObject(objects, Formatting.Indented);
        }
        public G? Deserialize<G>(string serializedObject)
        {
            return JsonConvert.DeserializeObject<G>(serializedObject);
        }
    }
}
