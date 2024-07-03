using App.Back.Domain.State.Komentari.Base;

namespace App.Back.Domain.State.Komentari
{
    public class ObrisanKomentar : StanjeKomentara
    {
        public ObrisanKomentar() {
            _state = Enums.StateComment.Deleted;
        }
        public override void ChangeState(Comment komentar)
        {
            return;
        }
    }
}
