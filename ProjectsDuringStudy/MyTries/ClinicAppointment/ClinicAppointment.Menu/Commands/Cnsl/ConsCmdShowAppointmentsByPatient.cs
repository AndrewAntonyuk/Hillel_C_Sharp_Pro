using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Helper.Validators.General.Implements;
using ClinicAppointment.Helper.Validators.General;
using ClinicAppointment.Menu.Interfaces;
using ClinicAppointment.Service.Interfaces;
using ClinicAppointment.Service.Services;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public class ConsCmdShowAppointmentsByPatient : IMenuCommand
    {
        public void Execute()
        {
            IAppointmentService _appointmentService = new AppointmentService();
            IEnumerable<Appointment>? _appointments;

            IGeneralValidator<int> _validator = new GeneralValidatorId();
            Console.WriteLine("Please enter id of patient:");
            Patient _patient = ConsWorkWithObjects.GetUserById<IPatientService, Patient>(new PatientService());

            _appointments = _appointmentService.GetAllByPatient(_patient);

            if (_appointments != null)
            {
                Console.WriteLine($"All appointments with patient {_patient.Name} {_patient.Surname}:");
                _appointments.ToList().ForEach(x => _appointmentService.ShowInfo(x));
            }
            else
            {
                Console.WriteLine($"\nCouldn't find appointments with patient {_patient.Name} {_patient.Surname}");
            }
        }
    }
}
