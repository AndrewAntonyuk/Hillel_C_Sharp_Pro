using ClinicAppointment.Domain.Entities;

namespace ClinicAppointment.Data.Interfaces
{
    public interface IGenericRepository<TSource> where TSource : Auditable
    {
        TSource Create(TSource source);

        TSource? GetById(int id);

        TSource Update(int id, TSource source);

        IEnumerable<TSource> GetAll();

        void ShowInfo(TSource user);

        bool Delete(int id);
    }
}
