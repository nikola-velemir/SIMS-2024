using App.Back.Domain.State.Recenzije.Base;

namespace App.Back.Domain.State.Recenzije
{
    public class PodRazmatranjemRecenzija : StanjeRecenzije
    {
        public PodRazmatranjemRecenzija() {
            _stanje = Enums.StateReview.UnderReview;
        }
        public override void PromeniStanje(Review recenzija)
        {
            if (recenzija.AcceptedReview)
            {
                recenzija.State = new PrihvacenaRecenzija();
                return;
            }
            recenzija.State = new OdbijenaRecenzija();
        }
    }
}
