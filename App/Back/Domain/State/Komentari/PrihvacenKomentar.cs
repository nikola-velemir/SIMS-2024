using App.Back.Domain.State.Komentari.Base;

namespace App.Back.Domain.State.Komentari
{
    public class PrihvacenKomentar : StanjeKomentara
    {
        public PrihvacenKomentar() {
            _stanje = Enums.StateKomentara.Prihvacen;
        }
        public override void PromeniStanje(Komentar komentar)
        {
            return;
        }
    }
}
