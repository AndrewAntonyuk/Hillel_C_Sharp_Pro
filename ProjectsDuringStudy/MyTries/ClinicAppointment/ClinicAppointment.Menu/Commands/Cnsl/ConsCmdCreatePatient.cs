using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Domain.Enums;
using ClinicAppointment.Helper.Extentions;
using ClinicAppointment.Helper.Validators.General.Implements;
using ClinicAppointment.Helper.Validators.General;
using ClinicAppointment.Menu.Interfaces;
using ClinicAppointment.Service.Services;
using ClinicAppointment.Service.Interfaces;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public class ConsCmdCreatePatient : IMenuCommand
    {
        public void Execute()
        {
            Patient _patient = new Patient();
            IPatientService _patientService = new PatientService();

            IGeneralValidator<string> _stringValidator = new GeneralValidatorString();
            Console.WriteLine("Please enter name of patient:");
            _patient.Name = _stringValidator.Validate(Console.ReadLine());

            Console.WriteLine("Please enter surname of patient:");
            _patient.Surname = _stringValidator.Validate(Console.ReadLine());

            _stringValidator = new GeneralValidatorPhone();
            Console.WriteLine("Please enter phone of patient:");
            _patient.Phone = _stringValidator.Validate(Console.ReadLine());

            _stringValidator = new GeneralValidatorEmail();
            Console.WriteLine("Please enter email of patient:");
            _patient.Email = _stringValidator.Validate(Console.ReadLine());

            IGeneralValidator<IllnessTypes> _enumValidator = new GeneralValidatorEnum<IllnessTypes>();
            Console.WriteLine("Please enter type of ilness (available types):");
            EnumExtention.ShowEnumDescription(IllnessTypes.DentalDisease);
            _patient.IllnessType = _enumValidator.Validate(Console.ReadLine());

            Console.WriteLine("Please enter additional information of patient:");
            _patient.AddittionalInfo = Console.ReadLine();

            Console.WriteLine("Please enter address of patient:");
            _patient.Address = Console.ReadLine();

            _patient = _patientService.Create(_patient);

            if (_patient != null)
            {
                Console.WriteLine("\nWas created the next patient:");
                _patientService.ShowInfo(_patient);
            }
            else
            {
                Console.WriteLine("\nCouldn't create patient");
            }
        }
    }
}
