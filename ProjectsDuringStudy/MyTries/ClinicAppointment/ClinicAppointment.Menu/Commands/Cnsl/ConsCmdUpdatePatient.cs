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
                ConsWorkWithObjects.UpdateUserById(_patient);

                IGeneralValidator<IllnessTypes> _enumValidator = new GeneralValidatorEnum<IllnessTypes>();
                Console.WriteLine("Please enter new type of ilness (available types):");
                EnumExtension.ShowEnumDescription(IllnessTypes.DentalDisease);
                _patient.IllnessType = _enumValidator.Validate(Console.ReadLine());

                Console.WriteLine("Please enter new additional information of patient:");
                _patient.AdditionalInfo = Console.ReadLine();

                Console.WriteLine("Please enter new address of patient:");
                _patient.Address = Console.ReadLine();

                _patient = _patientService.Update(_userId, _patient);

                ConsWorkWithObjects.ResultObjectInform(_patient, _patientService);
            }
            else
            {
                Console.WriteLine($"\nCouldn't find patient with id {_userId}");
            }
        }
    }
}
