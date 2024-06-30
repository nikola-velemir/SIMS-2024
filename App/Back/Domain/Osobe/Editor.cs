namespace App.Back.Domain.Osobe
{
    public class Editor : Person
    {
        public Editor(int id, string ime, string prezime, string jmbg, DateOnly datumRodjenja, Genders pol) 
            : base(id, ime, prezime, jmbg, datumRodjenja, pol,Role.Editor) { }
        public Editor(int id, string ime, string prezime, string jmbg, DateOnly datumRodjenja, Genders pol, int idNaloga) 
            : base(id, ime, prezime, jmbg, datumRodjenja, pol, idNaloga, Role.Editor) { }
        public Editor(Editor other)
        {
            FirstName = other.FirstName;
            LastName = other.LastName;
            JMBG = other.JMBG;
            BirthDate = other.BirthDate;
            Gender = other.Gender;
            AccountId = other.AccountId;
            Role = other.Role;
        }
        public void dodajMuzickoDelo(MusicalPiece delo)
        {
        }
    }
}
