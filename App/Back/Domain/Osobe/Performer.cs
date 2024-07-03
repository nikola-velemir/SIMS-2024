namespace App.Back.Domain.Osobe
{
    public class Performer : Person
    {
        public Performer() : base() { }
        public Performer(int id, string ime, string prezime, string jmbg, DateOnly datumRodjenja, Genders pol) : base(id, ime, prezime, jmbg, datumRodjenja, pol, Role.Performer)
        {
        }
        public Performer(int id, string ime, string prezime, string jmbg, DateOnly datumRodjenja, Genders pol, int idNaloga) : base(id, ime, prezime, jmbg, datumRodjenja, pol, idNaloga, Role.Performer)
        {
        }
        public Performer(Performer other)
        {
            FirstName = other.FirstName;
            LastName = other.LastName;
            JMBG = other.JMBG;
            BirthDate = other.BirthDate;
            Gender = other.Gender;
            AccountId = other.AccountId;
            Role = other.Role;
        }
    }
}
