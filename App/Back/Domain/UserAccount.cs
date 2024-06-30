namespace App.Back.Domain
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public AccountType Type { get; set; }

        public int IdOsobe { get; set; }
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
            IsActive = aktivan;
            Type = tip;
            IdOsobe = idOsobe;
        }
        public UserAccount(UserAccount other)
        {
            Id = other.Id;
            Type = other.Type;
            Password = other.Password;
            IsActive = other.IsActive;
            UserName = other.UserName;
            IdOsobe = other.IdOsobe;
        }
        
    }
}
