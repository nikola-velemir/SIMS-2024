namespace App.Repository.Interface
{
    public interface IRepository<Z>
    {
        public Z? Get(Z instance);
        public Z? Create(Z instance);
        public Z? Update(Z instance);
        public Z? Delete(Z instance);
        public List<Z> GetAll();
    }
}
