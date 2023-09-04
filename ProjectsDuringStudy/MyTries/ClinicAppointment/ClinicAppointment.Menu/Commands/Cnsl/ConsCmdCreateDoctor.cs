using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Domain.Enums;
using ClinicAppointment.Helper.Extentions;
using ClinicAppointment.Helper.Validators.General;
using ClinicAppointment.Helper.Validators.General.Implements;
using ClinicAppointment.Menu.Interfaces;
using ClinicAppointment.Service.Interfaces;
using ClinicAppointment.Service.Services;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public class ConsCmdCreateDoctor : IMenuCommand
    {
        public void Execute()
        {
            IDoctorService _doctorService = new DoctorService();

            Console.WriteLine("Please, enter all essential information for new doctor:");

            Doctor _doctor = ConsWorkWithObjects.CreateUser<Doctor>();

            IGeneralValidator<DoctorTypes> _enumValidator = new GeneralValidatorEnum<DoctorTypes>();
            Console.WriteLine("Please enter type of doctor (available types):");
            EnumExtension.ShowEnumDescription(DoctorTypes.Paramedic);
            _doctor.DoctorType = _enumValidator.Validate(Console.ReadLine());

            IGeneralValidator<decimal> _salaryValidator = new GeneralValidatorSalary();
            Console.WriteLine("Please enter salary:");
            _doctor.Salary = _salaryValidator.Validate(Console.ReadLine());

            IGeneralValidator<byte> _ageValidator = new GeneralValidatorAge();
            Console.WriteLine("Please enter experience:");
            _doctor.Experience = _ageValidator.Validate(Console.ReadLine());

            _doctor = _doctorService.Create(_doctor);

            ConsWorkWithObjects.ResultObjectInform(_doctor, _doctorService);
        }
    }
}
