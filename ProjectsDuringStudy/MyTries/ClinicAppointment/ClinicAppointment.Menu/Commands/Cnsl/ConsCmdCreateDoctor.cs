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
            Doctor _doctor = new Doctor();
            IDoctorService _doctorService = new DoctorService();

            IGeneralValidator<string> _stringValidator = new GeneralValidatorString();
            Console.WriteLine("Please enter name of doctor:");
            _doctor.Name = _stringValidator.Validate(Console.ReadLine());

            Console.WriteLine("Please enter surname of doctor:");
            _doctor.Surname = _stringValidator.Validate(Console.ReadLine());

            _stringValidator = new GeneralValidatorPhone();
            Console.WriteLine("Please enter phone of doctor:");
            _doctor.Phone = _stringValidator.Validate(Console.ReadLine());

            _stringValidator = new GeneralValidatorEmail();
            Console.WriteLine("Please enter email of doctor:");
            _doctor.Email = _stringValidator.Validate(Console.ReadLine());

            IGeneralValidator<DoctorTypes> _enumValidator = new GeneralValidatorEnum<DoctorTypes>();
            Console.WriteLine("Please enter type of doctor (available types):");
            EnumExtention.ShowEnumDescription(DoctorTypes.Paramedic);
            _doctor.DoctorType = _enumValidator.Validate(Console.ReadLine());

            IGeneralValidator<decimal> _salaryValidator = new GeneralValidatorSalary();
            Console.WriteLine("Please enter salary of doctor:");
            _doctor.Salary = _salaryValidator.Validate(Console.ReadLine());

            IGeneralValidator<byte> _ageValidator = new GeneralValidatorAge();
            Console.WriteLine("Please enter experience of doctor:");
            _doctor.Experiance = _ageValidator.Validate(Console.ReadLine());

            _doctor = _doctorService.Create(_doctor);

            if( _doctor != null )
            {
                Console.WriteLine("\nWas created the next doctor:");
                _doctorService.ShowInfo(_doctor);
            }
            else
            {
                Console.WriteLine("\nCouldn't create doctor");
            }  
        }
    }
}
