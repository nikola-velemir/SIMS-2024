using App.Back.Service;
using App.Front.ViewModels.DTO;
using App.Front.ViewModels.ViewControllers;
using System.Collections.ObjectModel;

namespace App.Front.ViewModels.Presentation.Wrappers
{
    public class MusicalPieceWrapperViewModel
    {
        public MusicPieceDTO Piece { get; set; }
        public PictureViewModel Picture { get; set; }
        public ObservableCollection<PerformerViewModel> Performers { get; set; }
        public MusicalGenreDTO Genre { get; set; }
        public MusicalPieceWrapperViewModel() { }
        public MusicalPieceWrapperViewModel(MusicPieceDTO piece, PictureViewModel picture, ObservableCollection<PerformerViewModel> performer, MusicalGenreDTO genre)
        {
            Piece = piece;
            Picture = picture;
            Performers = performer;
            Genre = genre;
        }
        public MusicalPieceWrapperViewModel(MusicPieceDTO piece)
        {
            Piece = piece;
            Performers = new();

            var pictureService = new PictureService();
            var participationService = new ParticipationService();
            var genreService = new MusicalGenreService();

            Picture = new PictureViewModel(pictureService.GetById(Piece.ProfilePicture.Id) ?? new Back.Domain.Picture());
            Genre = genreService.GetById(Piece.MusicalGenre.Id) ?? new MusicalGenreDTO();
            foreach (var p in participationService.GetPerformersByPieceId(Piece.Id))
            {
                Performers.Add(new PerformerViewModel(p));
            }

        }
    }
}
