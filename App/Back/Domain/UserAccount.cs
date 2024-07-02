namespace App.Back.Domain
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public bool Active { get; set; }
        public AccountType Type { get; set; }

        public int PersonId { get; set; }
        public UserAccount()
        {
            Password = string.Empty;
            UserName = string.Empty;
        }
        public UserAccount(int id, string lozinka, string korisnickoIme, bool aktivan, AccountType tip, int idOsobe)
        {
            Id = id;
            Password = lozinka;
            UserName = korisnickoIme;
            Active = aktivan;
            Type = tip;
            PersonId = idOsobe;
        }
        public UserAccount(UserAccount other)
        {
            Id = other.Id;
            Type = other.Type;
            Password = other.Password;
            Active = other.Active;
            UserName = other.UserName;
            PersonId = other.PersonId;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            UserAccount other = (UserAccount)obj;
            return Id == other.Id &&
                   Password == other.Password &&
                   UserName == other.UserName &&
                   Active == other.Active &&
                   Type == other.Type &&
                   PersonId == other.PersonId;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Id.GetHashCode();
            hash = hash * 23 + (Password?.GetHashCode() ?? 0);
            hash = hash * 23 + (UserName?.GetHashCode() ?? 0);
            hash = hash * 23 + Active.GetHashCode();
            hash = hash * 23 + Type.GetHashCode();
            hash = hash * 23 + PersonId.GetHashCode();
            return hash;
        }
    }
}
