namespace App.Back.Domain
{
    public class Biography
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<int> Pictures { get; set; }

        public Biography(int id, string tekst, List<Picture> slike)
        {
            Text = tekst;
            Pictures = new List<int>(id);
            Id = id;
            AddSlikeId(slike);
        }
        private void AddSlikeId(List<Picture> slike)
        {
            foreach (Picture slika in slike)
            {
                if (Pictures.Count != 0 && Pictures.Contains(slika.Id)) { continue; }
                Pictures.Add(slika.Id);
            }
        }
        public Biography(int id, string tekst, List<int> slike)
        {
            Text = tekst;
            Pictures = slike;
            Id = id;
        }
        public Biography(Biography other)
        {
            Text = other.Text;
            Pictures = other.Pictures;
            Id = other.Id;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Biography other = (Biography)obj;
            return Id == other.Id &&
                   Text == other.Text &&
                   Pictures.SequenceEqual(other.Pictures);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Id.GetHashCode();
                hash = hash * 23 + (Text != null ? Text.GetHashCode() : 0);
                foreach (var pictureId in Pictures)
                {
                    hash = hash * 23 + pictureId.GetHashCode();
                }
                return hash;
            }
        }
    }
}
