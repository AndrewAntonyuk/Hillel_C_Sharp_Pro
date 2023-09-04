using ClinicAppointment.Data.Interfaces;
using ClinicAppointment.Data.Repositories;
using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Service.Interfaces;

namespace ClinicAppointment.Service.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService()
        {
            _appointmentRepository = new AppointmentRepository();
        }

        public Appointment Create(Appointment appointment)
        {
            return _appointmentRepository.Create(appointment);
        }

        public bool Delete(int id)
        {
            return _appointmentRepository.Delete(id);
        }

        public Appointment? Get(int id)
        {
            return _appointmentRepository.GetById(id);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public IEnumerable<Appointment> GetAllByDoctor(Doctor doctor)
        {
            return _appointmentRepository.GetAllByDoctor(doctor);
        }

        public IEnumerable<Appointment> GetAllByPatient(Patient patient)
        {
            return _appointmentRepository.GetAllByPatient(patient);
        }

        public void ShowInfo(Appointment appointment)
        {
            _appointmentRepository.ShowInfo(appointment);
        }

        public Appointment Update(int id, Appointment appointment)
        {
            return _appointmentRepository.Update(id, appointment);
        }
    }
}
