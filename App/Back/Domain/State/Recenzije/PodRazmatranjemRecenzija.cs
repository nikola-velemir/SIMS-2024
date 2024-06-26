using App.Back.Domain.State.Recenzije.Base;

namespace App.Back.Domain.State.Recenzije
{
    public class PodRazmatranjemRecenzija : StanjeRecenzije
    {
        public PodRazmatranjemRecenzija() {
            _stanje = Enums.StateRecenzija.PodRazmatranjem;
        }
        public override void PromeniStanje(Recenzija recenzija)
        {
            if (recenzija.PrihvatioRecenziju)
            {
                recenzija.Stanje = new PrihvacenaRecenzija();
                return;
            }
            recenzija.Stanje = new OdbijenaRecenzija();
        }
    }
}
