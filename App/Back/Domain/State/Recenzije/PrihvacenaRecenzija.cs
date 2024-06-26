using App.Back.Domain.State.Recenzije.Base;

namespace App.Back.Domain.State.Recenzije
{
    public class PrihvacenaRecenzija : StanjeRecenzije
    {
        public PrihvacenaRecenzija() {
            _stanje = Enums.StateRecenzija.Prihvacena;
        }
        public override void PromeniStanje(Recenzija recenzija)
        {
            return;
        }
    }
}
