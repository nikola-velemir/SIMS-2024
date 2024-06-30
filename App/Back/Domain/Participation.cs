using App.Back.Domain.Osobe;

namespace App.Back.Domain
{
    public class Participation
    {
        public int PieceId { get; set; }
        public int PerformerId { get; set; }
        public int PerformerTypeId { get; set; }
       
        public Participation() { }
        public Participation(MusicalPiece delo, Performer izvodjac, PeformerType tipUcesnika)
        {
            PieceId = delo.Id;
            PerformerTypeId = tipUcesnika.Id;
            PerformerId = izvodjac.Id;
        }
        public Participation(int idDela, int idIzvodjaca, int idTipaUcesnika)
        {
            PieceId = idDela;
            PerformerId = idIzvodjaca;
            PerformerTypeId = PerformerTypeId;
        }
        public Participation(Participation other)
        {
            PieceId = other.PieceId;
            PerformerId = other.PerformerId;
            PerformerTypeId = other.PerformerTypeId;
        }
    }
}
