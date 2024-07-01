using App.Back.Domain.State.Enums;

namespace App.Back.Domain.State.Recenzije.Base
{
    public abstract class StanjeRecenzije
    {
        protected StateReview _stanje;

        public StateReview Stanje
        {
            get
            {
                return _stanje;
            }
        }

        public virtual void PromeniStanje(Review recenzija)
        {
           throw new NotImplementedException();
        }
    }
}
