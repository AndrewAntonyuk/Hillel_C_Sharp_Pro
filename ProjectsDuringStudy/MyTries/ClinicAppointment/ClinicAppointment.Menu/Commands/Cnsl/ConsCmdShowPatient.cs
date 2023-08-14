using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Helper.Validators.General.Implements;
using ClinicAppointment.Helper.Validators.General;
using ClinicAppointment.Menu.Interfaces;
using ClinicAppointment.Service.Interfaces;
using ClinicAppointment.Service.Services;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public class ConsCmdShowPatient : IMenuCommand
    {
        public void Execute()
        {
            IPatientService _patientService = new PatientService();

            IGeneralValidator<int> _validator = new GeneralValidatorId();
            Console.WriteLine("Please enter id of patient:");
            int _userId = _validator.Validate(Console.ReadLine());

            Patient? _patient = _patientService.Get(_userId);

            if (_patient != null)
            {
                Console.WriteLine("\nInformation about patient:");
                _patientService.ShowInfo(_patient);
            }
            else
            {
                Console.WriteLine($"\nCouldn't find patient with id {_userId}");
            }
        }
    }
}
