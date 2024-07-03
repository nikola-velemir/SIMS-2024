using App.Back.Domain.State.Recenzije.Base;

namespace App.Back.Domain.State.Recenzije
{
    public class OtvorenaRecenzija : StanjeRecenzije
    {
        public OtvorenaRecenzija()
        {
            _stanje = Enums.StateReview.Open;
        }
        public override void PromeniStanje(Review recenzija)
        {
            recenzija.State = new PodRazmatranjemRecenzija();
        }
    }
}
