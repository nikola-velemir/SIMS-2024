using App.Back.Domain.State.Komentari.Base;

namespace App.Back.Domain.State.Komentari
{
    public class DraftKomentar : StanjeKomentara
    {
        public DraftKomentar() {
            _stanje = Enums.StateKomentara.Draft;
        }
        public override void PromeniStanje(Komentar komentar)
        {
            if (komentar.OdustaoOdPisanja)
            {
                komentar.Stanje = new ObrisanKomentar();
                return;
            }
            komentar.Stanje = new OtvorenKomentar();

        }
    }
}
