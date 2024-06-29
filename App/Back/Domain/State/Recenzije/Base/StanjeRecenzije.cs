using App.Back.Domain.State.Enums;

namespace App.Back.Domain.State.Recenzije.Base
{
    public abstract class StanjeRecenzije
    {
        protected StateRecenzija _stanje;

        public StateRecenzija Stanje
        {
            get
            {
                return _stanje;
            }
        }

        public virtual void PromeniStanje(Recenzija recenzija)
        {
           throw new NotImplementedException();
        }
    }
}
