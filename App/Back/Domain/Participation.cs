using App.Back.Domain.Osobe;

namespace App.Back.Domain
{
    public class Participation
    {
        public int PieceId { get; set; }
        public int PerformerId { get; set; }
        public int PerformerTypeId { get; set; }
       
        public Participation() { }
        public Participation(MusicalPiece delo, Performer izvodjac, PerformerType tipUcesnika)
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
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Participation other = (Participation)obj;
            return PieceId == other.PieceId &&
                   PerformerId == other.PerformerId &&
                   PerformerTypeId == other.PerformerTypeId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + PieceId.GetHashCode();
                hash = hash * 23 + PerformerId.GetHashCode();
                hash = hash * 23 + PerformerTypeId.GetHashCode();
                return hash;
            }
        }
    }
}
