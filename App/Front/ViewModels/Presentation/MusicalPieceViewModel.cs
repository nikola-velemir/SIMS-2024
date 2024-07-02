using App.Back.Domain;
using System.ComponentModel;

namespace App.Front.ViewModels.Presentation
{
    public class MusicalPieceViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public int Id {  get; set; }
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

        private int musicalGenreId;
        public int MusicalGenreId
        {
            get { return musicalGenreId; }
            set
            {
                if(value != null)
                {
                    musicalGenreId = value;
                    OnPropertyChanged("MusicalGenreId");
                }
            }
        }
        private List<Picture> pictures;
        public List<Picture> Pictures
        {
            get {return pictures;}
            set
            {
                if(value != null)
                {
                    pictures = value;
                    OnPropertyChanged("Pictures");
                }
            }
        }
        private int profilePictureId;
        public int ProfilePictureId
        {
            get { return profilePictureId; }
            set
            {
                if (value != profilePictureId)
                {
                    profilePictureId = value;
                    OnPropertyChanged("ProfilePictureId");
                }
            }
        }
        public MusicalPieceViewModel() 
        {
            Pictures = new List<Picture>();
        }

        public MusicalPieceViewModel(MusicalPiece musicalPerformance) 
        {
            Id = musicalPerformance.Id;
            Description = musicalPerformance.Description;
            MusicalGenreId = musicalPerformance.MusicalGenreId;
            ProfilePictureId = musicalPerformance.ProfileImageId;
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
                    if (MusicalGenreId <= 0)
                    {
                        return "Musical performance must have a genre";
                    }
                }
                else if (columnName == "Pictures") 
                {
                    if(Pictures.Count == 0)
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
            foreach(var picture in Pictures)
            {
                ids.Add(picture.Id);
            }
            return ids;
        }
        public MusicalPiece ToMusicalPerformance()
        {
            var ids = GetPicturesId();
            return new MusicalPiece(Id, Description, ids, MusicalGenreId,ProfilePictureId);
        }
    }
}
