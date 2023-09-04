using ClinicAppointment.Domain.Entities;

namespace ClinicAppointment.Service.Interfaces
{
    public interface IService<T> where T : Auditable
    {
        T Create(T obj);

        IEnumerable<T> GetAll();

        T? Get(int id);

        bool Delete(int id);

        T Update(int id, T obj);

        void ShowInfo(T obj);
    }
}
