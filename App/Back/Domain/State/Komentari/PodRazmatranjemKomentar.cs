using App.Back.Domain.State.Komentari.Base;

namespace App.Back.Domain.State.Komentari
{
    public class PodRazmatranjemKomentar : StanjeKomentara
    {
        public PodRazmatranjemKomentar() {
            _stanje = Enums.StateKomentara.PodRazmatranjem;
        }
        public override void PromeniStanje(Komentar komentar)
        {
            if (komentar.OdobrioKomentar)
            {
                komentar.Stanje = new PrihvacenKomentar();
                return;
            }
            komentar.Stanje = new OdbijenKomentar();
        }
    }
}
