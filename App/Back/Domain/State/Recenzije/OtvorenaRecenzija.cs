using App.Back.Domain.State.Recenzije.Base;

namespace App.Back.Domain.State.Recenzije
{
    public class OtvorenaRecenzija : StanjeRecenzije
    {
        public OtvorenaRecenzija()
        {
            _stanje = Enums.StateRecenzija.Otvorena;
        }
        public override void PromeniStanje(Recenzija recenzija)
        {
            recenzija.Stanje = new PodRazmatranjemRecenzija();
        }
    }
}
