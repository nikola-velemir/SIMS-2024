using App.Back.Domain.State.Enums;

namespace App.Back.Domain.State.Komentari.Base
{
    public abstract class StanjeKomentara
    {
        protected StateKomentara _stanje;

        public StateKomentara Stanje
        {
            get
            {
                return _stanje;
            }
        }

        public virtual void PromeniStanje(Komentar komentar)
        {
            throw new NotImplementedException();
        }
    }
}
