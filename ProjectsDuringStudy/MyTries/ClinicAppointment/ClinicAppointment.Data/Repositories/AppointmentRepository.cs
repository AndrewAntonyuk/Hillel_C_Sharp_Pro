using ClinicAppointment.Data.Configuration;
using ClinicAppointment.Data.Interfaces;
using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Helper.FileHandlers;

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

            if (FileType.ToLower().Equals("xml"))
                _fileHandler = new FileHandlerXml<Appointment>();
            else
                _fileHandler = new FileHandlerJson<Appointment>();
        }

        public override void ShowInfo(Appointment appointment)
        {
            if(appointment != null)
            {
                Console.WriteLine("Id appointment: " + appointment.Id + "; description: " + appointment.Description);
                Console.WriteLine("Doctor data: ");
                ((DoctorRepository)_doctorRepository).ShowInfo(appointment.Doctor);
                Console.WriteLine("Patient data: ");
                ((PatientRepository)_patientRepository).ShowInfo(appointment.Patient);
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

        public Appointment GetAllByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Appointment GetAllByPatient(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
