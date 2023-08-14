using ClinicAppointment.Domain.Entities;

namespace ClinicAppointment.Data.Interfaces
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        // you can add more specific methods
    }
}
