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
                IGeneralValidator<string> _stringValidator = new GeneralValidatorString();
                Console.WriteLine("Please enter new name of doctor:");
                _doctor.Name = _stringValidator.Validate(Console.ReadLine());

                Console.WriteLine("Please enter new surname of doctor:");
                _doctor.Surname = _stringValidator.Validate(Console.ReadLine());

                _stringValidator = new GeneralValidatorPhone();
                Console.WriteLine("Please enter new phone of doctor:");
                _doctor.Phone = _stringValidator.Validate(Console.ReadLine());

                _stringValidator = new GeneralValidatorEmail();
                Console.WriteLine("Please enter new email of doctor:");
                _doctor.Email = _stringValidator.Validate(Console.ReadLine());

                IGeneralValidator<DoctorTypes> _enumValidator = new GeneralValidatorEnum<DoctorTypes>();
                Console.WriteLine("Please enter new type of doctor (available types):");
                EnumExtention.ShowEnumDescription(DoctorTypes.Paramedic);
                _doctor.DoctorType = _enumValidator.Validate(Console.ReadLine());

                IGeneralValidator<decimal> _salaryValidator = new GeneralValidatorSalary();
                Console.WriteLine("Please enter new salary of doctor:");
                _doctor.Salary = _salaryValidator.Validate(Console.ReadLine());

                IGeneralValidator<byte> _ageValidator = new GeneralValidatorAge();
                Console.WriteLine("Please enter new experience of doctor:");
                _doctor.Experiance = _ageValidator.Validate(Console.ReadLine());

                _doctor = _doctorService.Update(_userId,_doctor);

                if (_doctor != null)
                {
                    Console.WriteLine("\nWas updated the next doctor:");
                    _doctorService.ShowInfo(_doctor);
                }
                else
                {
                    Console.WriteLine("\nCouldn't update doctor");
                }
            }
            else
            {
                Console.WriteLine($"\nCouldn't find doctor with id {_userId}");
            }            
        }
    }
}
