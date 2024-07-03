using App.Back.Domain.State.Recenzije.Base;

namespace App.Back.Domain.State.Recenzije
{
    public class DraftRecenzija : StanjeRecenzije
    {
        public DraftRecenzija() {
            _stanje = Enums.StateReview.Draft;
        }
        public override void PromeniStanje(Review recenzija)
        {
            if (recenzija.GaveUpOnWriting)
            {
                recenzija.State = new ObrisanaRecenzija();
                return;
            }
            recenzija.State = new OtvorenaRecenzija();

        }
    }
}
