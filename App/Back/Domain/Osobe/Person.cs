namespace App.Back.Domain.Osobe
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JMBG { get; set; }
        public DateOnly BirthDate { get; set; }
        public Genders Gender { get; set; }
        public int? AccountId { get; set; }
        public Role Role { get; set; }
        public Person()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            JMBG = string.Empty;
        }
        public Person(int id, string firstname, string lastName, string jmbg, DateOnly birthDate, Genders gender, Role role)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastName;
            JMBG = jmbg;
            BirthDate = birthDate;
            Gender = gender;
            AccountId = null;
            Role = role;
        }
        public Person(int id, string firstName, string lastName, string jmbg, DateOnly birthDate, Genders gender, int accountId, Role role)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            JMBG = jmbg;
            BirthDate = birthDate;
            Gender = gender;
            AccountId = accountId;
            Role = role;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Person other = (Person)obj;
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
