using App.Back.Domain.State.Komentari.Base;

namespace App.Back.Domain.State.Komentari
{
    public class OtvorenKomentar : StanjeKomentara
    {
        public OtvorenKomentar()
        {
            _state = Enums.StateComment.Open;
        }
        public override void ChangeState(Comment komentar)
        {
            komentar.State = new PodRazmatranjemKomentar();
        }
    }
}
