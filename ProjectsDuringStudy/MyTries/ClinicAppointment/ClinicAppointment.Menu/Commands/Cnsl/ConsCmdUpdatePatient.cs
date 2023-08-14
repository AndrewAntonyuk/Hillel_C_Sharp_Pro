using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Helper.Validators.General.Implements;
using ClinicAppointment.Helper.Validators.General;
using ClinicAppointment.Menu.Interfaces;
using ClinicAppointment.Service.Interfaces;
using ClinicAppointment.Service.Services;
using ClinicAppointment.Domain.Enums;
using ClinicAppointment.Helper.Extentions;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public class ConsCmdUpdatePatient : IMenuCommand
    {
        public void Execute()
        {
            Patient? _patient;
            IPatientService _patientService = new PatientService();

            IGeneralValidator<int> _validator = new GeneralValidatorId();
            Console.WriteLine("Please enter id of patient:");
            int _userId = _validator.Validate(Console.ReadLine());

            _patient = _patientService.Get(_userId);

            if (_patient != null)
            {
                IGeneralValidator<string> _stringValidator = new GeneralValidatorString();
                Console.WriteLine("Please enter new name of patient:");
                _patient.Name = _stringValidator.Validate(Console.ReadLine());

                Console.WriteLine("Please enter new surname of patient:");
                _patient.Surname = _stringValidator.Validate(Console.ReadLine());

                _stringValidator = new GeneralValidatorPhone();
                Console.WriteLine("Please enter new phone of patient:");
                _patient.Phone = _stringValidator.Validate(Console.ReadLine());

                _stringValidator = new GeneralValidatorEmail();
                Console.WriteLine("Please enter new email of patient:");
                _patient.Email = _stringValidator.Validate(Console.ReadLine());

                IGeneralValidator<IllnessTypes> _enumValidator = new GeneralValidatorEnum<IllnessTypes>();
                Console.WriteLine("Please enter new type of ilness (available types):");
                EnumExtention.ShowEnumDescription(IllnessTypes.DentalDisease);
                _patient.IllnessType = _enumValidator.Validate(Console.ReadLine());

                Console.WriteLine("Please enter new additional information of patient:");
                _patient.AddittionalInfo = Console.ReadLine();

                Console.WriteLine("Please enter new address of patient:");
                _patient.Address = Console.ReadLine();

                _patient = _patientService.Update(_userId,_patient);

                if (_patient != null)
                {
                    Console.WriteLine("\nWas updated the next patient:");
                    _patientService.ShowInfo(_patient);
                }
                else
                {
                    Console.WriteLine("\nCouldn't update patient");
                }
            }
            else
            {
                Console.WriteLine($"\nCouldn't find patient with id {_userId}");
            }
        }
    }
}
