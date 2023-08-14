using ClinicAppointment.Data.Interfaces;
using ClinicAppointment.Data.Repositories;
using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Service.Interfaces;

namespace ClinicAppointment.Service.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService()
        {
            _patientRepository = new PatientRepository();
        }

        public Patient Create(Patient patient)
        {
            return _patientRepository.Create(patient);
        }

        public bool Delete(int id)
        {
            return _patientRepository.Delete(id);
        }

        public Patient? Get(int id)
        {
            return _patientRepository.GetById(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }

        public void ShowInfo(Patient patient)
        {
            _patientRepository.ShowInfo(patient);
        }

        public Patient Update(int id, Patient patient)
        {
            return _patientRepository.Update(id, patient);
        }
    }
}
