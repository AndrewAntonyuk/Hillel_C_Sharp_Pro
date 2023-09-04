using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Domain.Enums;
using ClinicAppointment.Helper.Extentions;
using ClinicAppointment.Helper.Validators.General.Implements;
using ClinicAppointment.Helper.Validators.General;
using ClinicAppointment.Menu.Interfaces;
using ClinicAppointment.Service.Interfaces;
using ClinicAppointment.Service.Services;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public class ConsCmdUpdateDoctor : IMenuCommand
    {
        public void Execute()
        {
            Doctor? _doctor;
            IDoctorService _doctorService = new DoctorService();

            IGeneralValidator<int> _validator = new GeneralValidatorId();
            Console.WriteLine("Please enter id of doctor:");
            int _userId = _validator.Validate(Console.ReadLine());

            _doctor = _doctorService.Get(_userId);

            if (_doctor != null)
            {
                ConsWorkWithObjects.UpdateUserById(_doctor);

                IGeneralValidator<DoctorTypes> _enumValidator = new GeneralValidatorEnum<DoctorTypes>();
                Console.WriteLine("Please enter new type of doctor (available types):");
                EnumExtension.ShowEnumDescription(DoctorTypes.Paramedic);
                _doctor.DoctorType = _enumValidator.Validate(Console.ReadLine());

                IGeneralValidator<decimal> _salaryValidator = new GeneralValidatorSalary();
                Console.WriteLine("Please enter new salary of doctor:");
                _doctor.Salary = _salaryValidator.Validate(Console.ReadLine());

                IGeneralValidator<byte> _ageValidator = new GeneralValidatorAge();
                Console.WriteLine("Please enter new experience of doctor:");
                _doctor.Experience = _ageValidator.Validate(Console.ReadLine());

                _doctor = _doctorService.Update(_userId, _doctor);

                ConsWorkWithObjects.ResultObjectInform(_doctor, _doctorService);
            }
            else
            {
                Console.WriteLine($"\nCouldn't find doctor with id {_userId}");
            }
        }
    }
}
