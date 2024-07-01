using App.Back.Domain;
using System.ComponentModel;

namespace App.Front.ViewModels.Presentation
{
    public class PictureViewModel : INotifyPropertyChanged, IDataErrorInfo
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

        private string path;
        public string Path
        {
            get { return path; }
            set
            {
                if (value != null)
                {
                    path = value;
                    OnPropertyChanged("Path");
                }
            }
        }

        private readonly string[] _validatedProperties = { "Description", "Path"};

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
                if(columnName == "Path")
                {
                    if(string.IsNullOrEmpty(Path))
                    {
                        return "Picture must have a path";
                    }
                }
                return null;
            }
        }

        public PictureViewModel() { }

        public PictureViewModel(Picture picture)
        {
            Id = picture.Id;
            Description = picture.Description;
            Path = picture.Path;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Picture ToPicture()
        {
            return new Picture(Id, Description, Path);
        }
    }
}
