using App.Back.Domain.State.Komentari.Base;

namespace App.Back.Domain.State.Komentari
{
    public class PrihvacenKomentar : StanjeKomentara
    {
        public PrihvacenKomentar() {
            _state = Enums.StateComment.Accepted;
        }
        public override void ChangeState(Comment komentar)
        {
            return;
        }
    }
}
