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

    }
}
