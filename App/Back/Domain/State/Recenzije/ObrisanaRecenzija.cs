using App.Back.Domain.State.Recenzije.Base;

namespace App.Back.Domain.State.Recenzije
{
    public class ObrisanaRecenzija : StanjeRecenzije
    {
        public ObrisanaRecenzija() {
            _stanje = Enums.StateRecenzija.Obrisana;
        }
        public override void PromeniStanje(Recenzija recenzija)
        {
            return;
        }
    }
}
