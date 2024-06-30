using App.Back.Domain.State.Recenzije.Base;

namespace App.Back.Domain.State.Recenzije
{
    public class OdbijenaRecenzija : StanjeRecenzije
    {
        public OdbijenaRecenzija() {
            _stanje = Enums.StateReview.Rejected;
        }
        public override void PromeniStanje(Review recenzija)
        {
            if (recenzija.WantsToEdit)
            {
                recenzija.State = new DraftRecenzija();
                return;
            }
            recenzija.State = new ObrisanaRecenzija();
        }
    }
}
