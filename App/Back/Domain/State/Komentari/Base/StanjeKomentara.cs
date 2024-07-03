using App.Back.Domain.State.Enums;

namespace App.Back.Domain.State.Komentari.Base
{
    public abstract class StanjeKomentara
    {
        protected StateComment _state;

        public StateComment State
        {
            get
            {
                return _state;
            }
        }

        public virtual void ChangeState(Comment komentar)
        {
            throw new NotImplementedException();
        }
    }
}
