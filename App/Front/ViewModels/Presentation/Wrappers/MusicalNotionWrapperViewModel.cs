using App.Back.Domain;
using App.Back.Service;
using System.IO;
using System.Windows;

namespace App.Front.ViewModels.Presentation.Wrappers
{
    public class MusicalNotionWrapperViewModel
    {
        public MusicalNotionViewModel Notion { get; set; }
        public PictureViewModel Picture { get; set; }
        public MusicalGenreViewModel Genre { get; set; }

        public MusicalNotionWrapperViewModel(MusicalNotionViewModel notion, PictureViewModel picture, MusicalGenreViewModel genre)
        {
            Notion = notion;
            Picture = picture;
            Genre = genre;
        }
        public MusicalNotionWrapperViewModel(MusicalNotionViewModel notion)
        {

            Notion = notion;

            var pictureService = new PictureService();
            var genreService = new MusicalGenreService();

            Picture = new PictureViewModel(pictureService.GetById(notion.ProfileImageId) ?? new Picture());
            
            Genre = new MusicalGenreViewModel(genreService.GetById(notion.MusicalGenreId) ?? new MusicalGenre());
        }

    }
}
