using App.Back.Domain;
using System.ComponentModel;

namespace App.Front.ViewModels.DTO
{
    public class MusicPieceDTO : INotifyPropertyChanged, IDataErrorInfo
    {
        public int Id { get; set; }
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                if (value != null)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        private MusicGenre musicalGenre;
        public MusicGenre MusicalGenre
        {
            get { return musicalGenre; }
            set
            {
                if (value != null)
                {
                    musicalGenre = value;
                    OnPropertyChanged("MusicalGenreId");
                }
            }
        }
        private List<Picture> pictures;
        public List<Picture> Pictures
        {
            get { return pictures; }
            set
            {
                if (value != null)
                {
                    pictures = value;
                    OnPropertyChanged("Pictures");
                }
            }
        }
        private Picture profilePicture;
        public Picture ProfilePicture
        {
            get { return profilePicture; }
            set
            {
                if (value != profilePicture)
                {
                    profilePicture = value;
                    OnPropertyChanged("ProfilePictureId");
                }
            }
        }
        public MusicPieceDTO()
        {
            Pictures = new List<Picture>();
            ProfilePicture = new Picture();
        }

        public MusicPieceDTO(MusicPieceDTO musicalPiece)
        {
            Id = musicalPiece.Id;
            Description = musicalPiece.Description;
            MusicalGenre = musicalPiece.MusicalGenre;
            Pictures = musicalPiece.Pictures;
            ProfilePicture = musicalPiece.ProfilePicture;
        }

        public MusicPieceDTO(MusicalPiece musicalPiece)
        {
            Id = musicalPiece.Id;
            Description = musicalPiece.Description;
        }

        public MusicPieceDTO(int id, string description, MusicGenre musicalGenre, List<Picture> pictures, Picture profilePicture)
        {
            Id = id;
            Description = description;
            MusicalGenre = musicalGenre;
            Pictures = pictures;
            ProfilePicture = profilePicture;
        }

        public void AddPicture(Picture picture)
        {
            Pictures.Add(picture);
        }

        private readonly string[] _validatedProperties = { "Description", "MusicalGenreId", "Pictures" };

        public bool IsValid
        {
            get
            {
                foreach (var property in _validatedProperties)
                {
                    if (this[property] != null)
                        return false;
                }

                return true;
            }
        }
        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Description")
                {
                    if (string.IsNullOrEmpty(Description))
                    {
                        return "Musical performance must have a description";
                    }
                }
                else if (columnName == "MusicalGenreId")
                {
                    if (MusicalGenre == null)
                    {
                        return "Musical performance must have a genre";
                    }
                }
                else if (columnName == "Pictures")
                {
                    if (Pictures.Count == 0)
                    {
                        return "Musical performance must have at least one picture";
                    }
                }
                return null;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public List<int> GetPicturesId()
        {
            var ids = new List<int>();
            foreach (var picture in Pictures)
            {
                ids.Add(picture.Id);
            }
            return ids;
        }
        public MusicalPiece ToMusicPiece()
        {
            var ids = GetPicturesId();
            return new MusicalPiece(Id, Description, ids, MusicalGenre.Id, ProfilePicture.Id);
        }
    }
}
