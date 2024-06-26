using App.Back.Domain.State.Komentari.Base;

namespace App.Back.Domain.State.Komentari
{
    public class OdbijenKomentar : StanjeKomentara
    {
        public OdbijenKomentar() {
            _stanje = Enums.StateKomentara.Odbijen;
        }
        public override void PromeniStanje(Komentar komentar)
        {
            return;
        }
    }
}
