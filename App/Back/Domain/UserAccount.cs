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
        public UserAccount(int id, string password, string userName, bool active, AccountType accountType, int personId)
        {
            Id = id;
            Password = password;
            UserName = userName;
            Active = active;
            Type = accountType;
            PersonId = personId;
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
        
    }
}
