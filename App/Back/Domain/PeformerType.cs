namespace App.Back.Domain
{
    public class PeformerType
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public PeformerType()
        {
            Type = string.Empty;
        }
        public PeformerType(string tip, int id)
        {
            Type = tip;
            Id = id;
        }
        public PeformerType(PeformerType other)
        {
            Type = other.Type;
            Id = other.Id;
        }
    }
}
