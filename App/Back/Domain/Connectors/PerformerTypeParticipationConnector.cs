namespace App.Back.Domain.Connectors
{
    public class PerformerTypeParticipationConnector
    {
        public int PerformerTypeId { get; set; }
        public int PerformanceId { get; set; }
        public PerformerTypeParticipationConnector()
        {

        }
        public PerformerTypeParticipationConnector(int idTipUcesnika, int idUcesce)
        {
            this.PerformerTypeId = idTipUcesnika;
            this.PerformanceId = idUcesce;
        }
        public PerformerTypeParticipationConnector(PerformerTypeParticipationConnector other)
        {
            PerformerTypeId = other.PerformerTypeId;
            PerformanceId = other.PerformanceId;
        }
    }
}
