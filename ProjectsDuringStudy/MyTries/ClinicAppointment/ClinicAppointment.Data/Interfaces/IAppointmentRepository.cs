using ClinicAppointment.Domain.Entities;

namespace ClinicAppointment.Data.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        // you can add more specific methods
        Appointment GetAllByDoctor(Doctor doctor);

        Appointment GetAllByPatient(Patient patient);
    }
}
