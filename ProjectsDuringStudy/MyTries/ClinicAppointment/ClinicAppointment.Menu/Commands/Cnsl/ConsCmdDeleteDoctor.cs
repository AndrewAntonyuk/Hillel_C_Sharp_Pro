using ClinicAppointment.Helper.Validators.General.Implements;
using ClinicAppointment.Helper.Validators.General;
using ClinicAppointment.Menu.Interfaces;
using ClinicAppointment.Service.Services;
using ClinicAppointment.Service.Interfaces;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public class ConsCmdDeleteDoctor : IMenuCommand
    {
        public void Execute()
        {
            IDoctorService _doctorService = new DoctorService();

            IGeneralValidator<int> _validator = new GeneralValidatorId();
            Console.WriteLine("Please enter id of doctor for deleting:");
            int _userId = _validator.Validate(Console.ReadLine());
            
            bool _deleted = _doctorService.Delete(_userId);        

            if (_deleted)
            {
                Console.WriteLine("\nDeleting is success:");
            }
            else
            {
                Console.WriteLine("\nCouldn't delete doctor");
            }
        }
    }
}
