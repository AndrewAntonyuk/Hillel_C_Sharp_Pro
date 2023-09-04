using ClinicAppointment.Data.Configuration;
using ClinicAppointment.Data.Interfaces;
using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Helper.Utils;

namespace ClinicAppointment.Data.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;

        public override string Path { get; set; }
        public override string FileType { get; set; }
        public override int LastId { get; set; }

        public AppointmentRepository()
        {
            _doctorRepository = new DoctorRepository();
            _patientRepository = new PatientRepository();

            dynamic result = ReadFromAppSettings();

            FileType = result.Database.FileType;
            Path = result.Database.Appointments.Path + "." + FileType;
            LastId = result.Database.Appointments.LastId;

            _fileHandler = FileUtils.GetFileHandler<Appointment>(result);
        }

        public override void ShowInfo(Appointment appointment)
        {
            if (appointment != null)
            {
                Console.WriteLine("Id appointment: " + appointment.Id + "; description: " + appointment.Description);
                Console.WriteLine("Doctor data: ");
                _doctorRepository.ShowInfo(appointment.Doctor);
                Console.WriteLine("Patient data: ");
                _patientRepository.ShowInfo(appointment.Patient);
                Console.WriteLine("From: " + appointment.DateTimeFrom.ToString() + " to: " + appointment.DateTimeTo.ToString());
            }
            else
            {
                throw new ArgumentNullException(nameof(appointment) + " can't be null");
            }
        }

        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Appointments.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, result.ToString());
        }

        protected override void CheckExist(IEnumerable<Appointment> arr, Appointment obj)
        {
            bool condition = obj != null
                             && arr.Any(app => app.DateTimeFrom.Equals(obj.DateTimeFrom)
                                        && app.DateTimeTo.Equals(obj.DateTimeTo)
                                        && (app.Doctor?.Id == obj.Doctor?.Id)
                                        && (app.Patient?.Id == obj.Patient?.Id));

            if (condition)
            {
                throw new ArgumentException($"Appointment: from {obj?.DateTimeFrom} to" +
                    $" {obj?.DateTimeTo} for doctor with id {obj?.Doctor?.Id} and patient with id {obj?.Patient?.Id} already exist!");
            }
        }

        public IEnumerable<Appointment> GetAllByDoctor(Doctor doctor)
        {
            var allAppointments = GetAll();

            var allByDoctor = from app in allAppointments
                              where app.Doctor?.Id == doctor?.Id
                              select app;

            return allByDoctor;
        }

        public IEnumerable<Appointment> GetAllByPatient(Patient patient)
        {
            return GetAll().Where(a => a.Patient?.Id == patient?.Id);
        }
    }
}
