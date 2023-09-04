using ClinicAppointment.Domain.Entities;

namespace ClinicAppointment.Data.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        IEnumerable<Appointment> GetAllByDoctor(Doctor doctor);

        IEnumerable<Appointment> GetAllByPatient(Patient patient);
    }
}
