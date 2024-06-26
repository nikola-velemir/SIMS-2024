using App.Back.Domain.State.Komentari.Base;

namespace App.Back.Domain.State.Komentari
{
    public class ObrisanKomentar : StanjeKomentara
    {
        public ObrisanKomentar() {
            _stanje = Enums.StateKomentara.Obrisan;
        }
        public override void PromeniStanje(Komentar komentar)
        {
            return;
        }
    }
}
