namespace App.Back.Domain
{
    public class PerformerType
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public PerformerType()
        {
            Type = string.Empty;
        }
        public PerformerType(string tip, int id)
        {
            Type = tip;
            Id = id;
        }
        public PerformerType(PerformerType other)
        {
            Type = other.Type;
            Id = other.Id;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            PerformerType other = (PerformerType)obj;
            return Type == other.Type && Id == other.Id;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Type != null ? Type.GetHashCode() : 0);
                hash = hash * 23 + Id.GetHashCode();
                return hash;
            }
        }
    }
}
