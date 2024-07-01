namespace App.Back.Domain.Connectors
{
    public class PlayListMusicalPieceConnector
    {
        public int PlayListId { get; set; }
        public int MusicalPieceId { get; set; }
        public PlayListMusicalPieceConnector() { }
        public PlayListMusicalPieceConnector(int idPlayListe, int idMuzickogDela)
        {
            PlayListId = idPlayListe;
            MusicalPieceId = idMuzickogDela;
        }
        public PlayListMusicalPieceConnector(PlayList playLista, MusicalPiece delo)
        {
            PlayListId = playLista.Id;
            MusicalPieceId = delo.Id;
        }
        public PlayListMusicalPieceConnector(PlayListMusicalPieceConnector other)
        {
            PlayListId = other.PlayListId;
            MusicalPieceId = other.MusicalPieceId;
        }
    }
}
