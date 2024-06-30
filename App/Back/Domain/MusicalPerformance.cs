namespace App.Back.Domain
{
    public class MusicalPerformance : MuzickiPojam
    {
        public List<int> Pictures { get; set; }
        public MusicalPerformance(int id, string description, List<int> pictures, int musicalGenreId) : base(id, description, musicalGenreId)
        {
            Pictures = pictures;
        }
        public void AddPicture(Slika picture)
        {
            Pictures.Add(picture.Id);
        }
    }
}
