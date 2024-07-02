namespace App.Back.Domain
{
    public class Picture
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }

        public Picture() {
            Description = string.Empty;
            Path = string.Empty;
        }
        public Picture(int id, string description, string path)
        {
            Id = id;
            Description = description;
            Path = path;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Picture other = (Picture)obj;
            return Id == other.Id &&
                   Description == other.Description &&
                   Path == other.Path;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Id.GetHashCode();
                hash = hash * 23 + (Description != null ? Description.GetHashCode() : 0);
                hash = hash * 23 + (Path != null ? Path.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
