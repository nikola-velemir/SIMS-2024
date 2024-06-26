using App.Back.Domain.State.Recenzije.Base;

namespace App.Back.Domain.State.Recenzije
{
    public class DraftRecenzija : StanjeRecenzije
    {
        public DraftRecenzija() {
            _stanje = Enums.StateRecenzija.Draft;
        }
        public override void PromeniStanje(Recenzija recenzija)
        {
            if (recenzija.OdustaoOdPisanja)
            {
                recenzija.Stanje = new ObrisanaRecenzija();
                return;
            }
            recenzija.Stanje = new OtvorenaRecenzija();

        }
    }
}
