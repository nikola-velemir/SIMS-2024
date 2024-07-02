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
                if(account.UserName == userAccount.UserName)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
