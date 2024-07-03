using App.Back.Domain.State.Recenzije.Base;

namespace App.Back.Domain.State.Recenzije
{
    public class ObrisanaRecenzija : StanjeRecenzije
    {
        public ObrisanaRecenzija() {
            _stanje = Enums.StateReview.Deleted;
        }
        public override void PromeniStanje(Review recenzija)
        {
            return;
        }
    }
}
