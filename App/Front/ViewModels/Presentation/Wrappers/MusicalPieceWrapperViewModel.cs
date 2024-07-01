using App.Back.Service;
using System.Collections.ObjectModel;

namespace App.Front.ViewModels.Presentation.Wrappers
{
    public class MusicalPieceWrapperViewModel
    {
        public MusicalPieceViewModel Piece { get; set; }
        public PictureViewModel Picture { get; set; }
        public ObservableCollection<PerformerViewModel> Performers { get; set; }
        public MusicalGenreViewModel Genre { get; set; }
        public MusicalPieceWrapperViewModel() { }
        public MusicalPieceWrapperViewModel(MusicalPieceViewModel piece, PictureViewModel picture, ObservableCollection<PerformerViewModel> performer, MusicalGenreViewModel genre)
        {
            Piece = piece;
            Picture = picture;
            Performers = performer;
            Genre = genre;
        }
        public MusicalPieceWrapperViewModel(MusicalPieceViewModel piece)
        {
            Piece = piece;
            Performers = new();

            var pictureService = new PictureService();
            var participationService = new ParticipationService();
            var genreService = new MusicalGenreService();

            Picture = new PictureViewModel(pictureService.GetById(Piece.ProfilePictureId) ?? new Back.Domain.Picture());
            Genre = new MusicalGenreViewModel(genreService.GetById(Piece.MusicalGenreId) ?? new Back.Domain.MusicalGenre());
            foreach (var p in participationService.GetPerformersByPieceId(Piece.Id))
            {
                Performers.Add(new PerformerViewModel(p));
            }

        }
    }
}
