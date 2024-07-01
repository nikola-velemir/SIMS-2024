using App.Back.Domain.State.Komentari.Base;

namespace App.Back.Domain
{
    public class Comment
    {
        int Id { get; set; }
        public StanjeKomentara State { get; set; }
        public bool GaveUpOnWriting { get; set; }
        public bool UnderReview { get; set; }
        public bool AcceptedComment { get; set; }
    }
}
