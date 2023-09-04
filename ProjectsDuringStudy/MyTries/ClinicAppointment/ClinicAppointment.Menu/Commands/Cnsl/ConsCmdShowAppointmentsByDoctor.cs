using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Helper.Validators.General.Implements;
using ClinicAppointment.Helper.Validators.General;
using ClinicAppointment.Menu.Interfaces;
using ClinicAppointment.Service.Interfaces;
using ClinicAppointment.Service.Services;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public class ConsCmdShowAppointmentsByDoctor : IMenuCommand
    {
        public void Execute()
        {
            IAppointmentService _appointmentService = new AppointmentService();
            IEnumerable<Appointment>? _appointments;

            IGeneralValidator<int> _validator = new GeneralValidatorId();
            Console.WriteLine("Please enter id of doctor:");
            Doctor _doctor = ConsWorkWithObjects.GetUserById<IDoctorService, Doctor>(new DoctorService());

            _appointments = _appointmentService.GetAllByDoctor(_doctor);

            if (_appointments != null)
            {
                Console.WriteLine($"All appointments with doctor {_doctor.Name} {_doctor.Surname}:");
                _appointments.ToList().ForEach(x => _appointmentService.ShowInfo(x));
            }
            else
            {
                Console.WriteLine($"\nCouldn't find appointments with doctor {_doctor.Name} {_doctor.Surname}");
            }
        }
    }
}
