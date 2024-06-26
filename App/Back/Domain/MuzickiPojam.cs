namespace App.Back.Domain
{
    public class MuzickiPojam
    {
        public int Id { get; set; }
        public string Opis { get; set; }

        public MuzickiPojam(int id, string opis)
        {
            Id = id;
            Opis = opis;
        }
    }
}
