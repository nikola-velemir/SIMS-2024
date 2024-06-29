namespace App.Back.Domain.Connectors
{
    public class PlayListaMuzickoDeloConnector
    {
        public int IdPlayListe { get; set; }
        public int IdMuzickogDela { get; set; }
        public PlayListaMuzickoDeloConnector() { }
        public PlayListaMuzickoDeloConnector(int idPlayListe, int idMuzickogDela)
        {
            IdPlayListe = idPlayListe;
            IdMuzickogDela = idMuzickogDela;
        }
        public PlayListaMuzickoDeloConnector(PlayLista playLista, MuzickoDelo delo)
        {
            IdPlayListe = playLista.Id;
            IdMuzickogDela = delo.Id;
        }
        public PlayListaMuzickoDeloConnector(PlayListaMuzickoDeloConnector other)
        {
            IdPlayListe = other.IdPlayListe;
            IdMuzickogDela = other.IdMuzickogDela;
        }
    }
}
