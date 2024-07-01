using App.Back.Domain.Osobe;

namespace App.Front.ViewModels.Presentation
{
    public class PerformerViewModel : PersonViewModel
    {
        public PerformerViewModel() : base() { }
        public PerformerViewModel(Performer izvodjac)
        {
            Id = izvodjac.Id;
            FirstName = izvodjac.FirstName;
            LastName = izvodjac.LastName;
            JMBG = izvodjac.JMBG;
            BirthDate = new DateTime(izvodjac.BirthDate, new TimeOnly(0, 0, 0));
            Gender = izvodjac.Gender;
        }
        public Performer ToPerformer()
        {
            return new Performer(Id, FirstName, LastName, JMBG, DateOnly.FromDateTime(BirthDate), Gender);
        }
    }
}
