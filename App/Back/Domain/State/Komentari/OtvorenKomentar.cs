using App.Back.Domain.State.Komentari.Base;

namespace App.Back.Domain.State.Komentari
{
    public class OtvorenKomentar : StanjeKomentara
    {
        public OtvorenKomentar()
        {
            _stanje = Enums.StateKomentara.Otvoren;
        }
        public override void PromeniStanje(Komentar komentar)
        {
            komentar.Stanje = new PodRazmatranjemKomentar();
        }
    }
}
