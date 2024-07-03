using App.Back.Domain;
using App.Back.Repository;

namespace App.Back.Service
{
    public class UserAccountService
    {
        private UserAccountRepository _repository;

        public UserAccountService()
        {
            _repository = new UserAccountRepository();
        }

        public UserAccount? Create(UserAccount instance)
        {
            return _repository.Create(instance);
        }

        public UserAccount? Delete(UserAccount instance)
        {
            return _repository.Delete(instance);
        }

        public UserAccount? Get(UserAccount instance)
        {
            return _repository.Get(instance);
        }

        public List<UserAccount> GetAll()
        {
            return _repository.GetAll();
        }

        public UserAccount? Update(UserAccount instance)
        {
            return _repository.Update(instance);
        }

        public UserAccount? GeyByUserName(string userName)
        {
            foreach (var account in _repository.GetAll())
            {
                if (account.UserName == userName)
                {
                    return account;
                }
            }
            return null;
        }

        public bool CanUserRegistrate(UserAccount userAccount)
        {
            foreach(var account in _repository.GetAll())
            {
                if(account.UserName == userAccount.UserName && account.Id != userAccount.Id)
                {
                    return false;
                }
            }
            return true;
        }

        public List<UserAccount> GetAllEditors()
        {
            var editors = new List<UserAccount>();
            foreach(var account in GetAll())
            {
                if(account.Type == AccountType.Editor && account.Active == true)
                {
                    editors.Add(account);
                }
            }
            return editors;
        }

        public UserAccount GetById(int? accountId)
        {
            foreach(var account in GetAll())
            {
                if(account.Id == accountId)
                {
                    return account;
                }
            }
            return new UserAccount();
        }
    }
}
