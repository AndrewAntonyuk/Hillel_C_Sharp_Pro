using ClinicAppointment.Helper.Validators.General.Implements;
using ClinicAppointment.Helper.Validators.General;
using ClinicAppointment.Menu.Interfaces;
using ClinicAppointment.Service.Services;
using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Service.Interfaces;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public class ConsCmdShowDoctor : IMenuCommand
    {
        public void Execute()
        {
            IDoctorService _doctorService = new DoctorService();

            IGeneralValidator<int> _validator = new GeneralValidatorId();
            Console.WriteLine("Please enter id of doctor:");
            int _userId = _validator.Validate(Console.ReadLine());

            Doctor? _doctor = _doctorService.Get(_userId);

            if (_doctor != null)
            {
                Console.WriteLine("\nInformation about doctor:");
                _doctorService.ShowInfo(_doctor);
            }
            else
            {
                Console.WriteLine($"\nCouldn't find doctor with id {_userId}");
            }
        }
    }
}
