using App.Back.Domain.State.Komentari.Base;

namespace App.Back.Domain.State.Komentari
{
    public class OdbijenKomentar : StanjeKomentara
    {
        public OdbijenKomentar() {
            _state = Enums.StateComment.Rejected;
        }
        public override void ChangeState(Comment komentar)
        {
            return;
        }
    }
}
