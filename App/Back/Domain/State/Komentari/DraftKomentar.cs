using App.Back.Domain.State.Komentari.Base;

namespace App.Back.Domain.State.Komentari
{
    public class DraftKomentar : StanjeKomentara
    {
        public DraftKomentar() {
            _state = Enums.StateComment.Draft;
        }
        public override void ChangeState(Comment komentar)
        {
            if (komentar.GaveUpOnWriting)
            {
                komentar.State = new ObrisanKomentar();
                return;
            }
            komentar.State = new OtvorenKomentar();

        }
    }
}
