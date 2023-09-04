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
            IPatientService _patientService = new PatientService();

            Console.WriteLine("Please, enter all essential information for new patient:");

            Patient _patient = ConsWorkWithObjects.CreateUser<Patient>();

            IGeneralValidator<IllnessTypes> _enumValidator = new GeneralValidatorEnum<IllnessTypes>();
            Console.WriteLine("Please enter type of illness (available types):");
            EnumExtension.ShowEnumDescription(IllnessTypes.DentalDisease);
            _patient.IllnessType = _enumValidator.Validate(Console.ReadLine());

            Console.WriteLine("Please enter additional information:");
            _patient.AdditionalInfo = Console.ReadLine();

            Console.WriteLine("Please enter address:");
            _patient.Address = Console.ReadLine();

            _patient = _patientService.Create(_patient);

            ConsWorkWithObjects.ResultObjectInform(_patient, _patientService);
        }
    }
}
