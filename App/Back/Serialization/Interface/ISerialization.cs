namespace App.Back.Serialization.Interface
{
    public interface ISerialization
    {
        public string Serialize<G>(G? @object);
        public G? Deserialize<G>(string serializedObject);
    }
}
