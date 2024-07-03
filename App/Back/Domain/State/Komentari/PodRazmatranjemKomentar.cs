using App.Back.Domain.State.Komentari.Base;

namespace App.Back.Domain.State.Komentari
{
    public class PodRazmatranjemKomentar : StanjeKomentara
    {
        public PodRazmatranjemKomentar() {
            _state = Enums.StateComment.UnderReview;
        }
        public override void ChangeState(Comment komentar)
        {
            if (komentar.AcceptedComment)
            {
                komentar.State = new PrihvacenKomentar();
                return;
            }
            komentar.State = new OdbijenKomentar();
        }
    }
}
