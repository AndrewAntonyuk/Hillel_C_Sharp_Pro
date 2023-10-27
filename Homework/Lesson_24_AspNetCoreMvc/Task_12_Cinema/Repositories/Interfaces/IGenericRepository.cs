namespace Task_12_Cinema.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T Create(T entity);

        void Delete(int id);

        T Edit(T entity);

        T GetById(int id);

        IEnumerable<T> GetAll();
    }
}
