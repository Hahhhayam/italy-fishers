using DAL.Entity;

namespace DAL.Repo
{
    public interface IRepository<T>
    {
        public T Get(int id);

        public IEnumerable<T> GetAll();

        public void Add(T entity);

        public void Update(int id, T entity);

        public void Delete(int id);
    }
}
