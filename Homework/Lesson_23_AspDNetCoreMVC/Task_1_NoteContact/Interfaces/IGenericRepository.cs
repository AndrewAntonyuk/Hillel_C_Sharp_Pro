namespace Task_1_NoteContact.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T? GetById(int? id);

        ICollection<T> GetAll();

        void Create(T entity);

        void Update(T entity);

        void Delete(int? id);
    }
}
