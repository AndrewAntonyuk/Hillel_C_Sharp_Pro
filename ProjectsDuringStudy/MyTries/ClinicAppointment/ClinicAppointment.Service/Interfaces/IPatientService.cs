using ClinicAppointment.Domain.Entities;

namespace ClinicAppointment.Service.Interfaces
{
    public interface IPatientService
    {
        Patient Create(Patient patient);

        IEnumerable<Patient> GetAll();

        Patient? Get(int id);

        bool Delete(int id);

        Patient Update(int id, Patient patient);

        void ShowInfo(Patient patient);
    }
}
