using App.Back.Domain;
using System.ComponentModel;

namespace App.Front.ViewModels.Presentation
{
    public class MusicalPerformanceDataViewModel : INotifyPropertyChanged, IDataErrorInfo
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

        public MusicalPerformanceDataViewModel() 
        {
            Pictures = new List<Picture>();
        }

        public MusicalPerformanceDataViewModel(MusicalPiece musicalPerformance) 
        {
            Id = musicalPerformance.Id;
            Description = musicalPerformance.Description;
            MusicalGenreId = musicalPerformance.MusicalGenreId;
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
            return new MusicalPiece(Id, Description, ids, MusicalGenreId);
        }
    }
}
