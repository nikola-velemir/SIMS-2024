namespace App.Back.Domain.Connectors
{
    public class TipUcesnikaUcesceConnector
    {
        public int IdTipUcesnika { get; set; }
        public int IdUcesce { get; set; }
        public TipUcesnikaUcesceConnector()
        {

        }
        public TipUcesnikaUcesceConnector(int idTipUcesnika, int idUcesce)
        {
            this.IdTipUcesnika = idTipUcesnika;
            this.IdUcesce = idUcesce;
        }
        public TipUcesnikaUcesceConnector(TipUcesnikaUcesceConnector other)
        {
            IdTipUcesnika = other.IdTipUcesnika;
            IdUcesce = other.IdUcesce;
        }
    }
}
