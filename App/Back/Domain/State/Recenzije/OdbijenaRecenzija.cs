using App.Back.Domain.State.Recenzije.Base;

namespace App.Back.Domain.State.Recenzije
{
    public class OdbijenaRecenzija : StanjeRecenzije
    {
        public OdbijenaRecenzija() {
            _stanje = Enums.StateRecenzija.Odbijena;
        }
        public override void PromeniStanje(Recenzija recenzija)
        {
            if (recenzija.HoceDaIzmeni)
            {
                recenzija.Stanje = new DraftRecenzija();
                return;
            }
            recenzija.Stanje = new ObrisanaRecenzija();
        }
    }
}
