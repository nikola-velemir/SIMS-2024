using App.Back.Domain.State.Recenzije.Base;

namespace App.Back.Domain.State.Recenzije
{
    public class PrihvacenaRecenzija : StanjeRecenzije
    {
        public PrihvacenaRecenzija() {
            _stanje = Enums.StateReview.Accepted;
        }
        public override void PromeniStanje(Review recenzija)
        {
            return;
        }
    }
}
