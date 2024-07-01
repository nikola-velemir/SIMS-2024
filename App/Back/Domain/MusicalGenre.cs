namespace App.Back.Domain
{
    public class MusicalGenre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MusicalGenre(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public MusicalGenre() {
            Name = string.Empty;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            MusicalGenre other = (MusicalGenre)obj;
            return Id == other.Id && Name == other.Name;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Id.GetHashCode();
                hash = hash * 23 + (Name != null ? Name.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
