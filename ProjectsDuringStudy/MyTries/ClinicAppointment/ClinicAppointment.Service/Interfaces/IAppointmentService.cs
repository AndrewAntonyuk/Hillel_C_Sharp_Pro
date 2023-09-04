using ClinicAppointment.Domain.Entities;

namespace ClinicAppointment.Service.Interfaces
{
    public interface IAppointmentService : IService<Appointment>
    {
        IEnumerable<Appointment> GetAllByDoctor(Doctor doctor);

        IEnumerable<Appointment> GetAllByPatient(Patient patient);
    }
}
