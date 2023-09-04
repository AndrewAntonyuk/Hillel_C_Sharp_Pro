﻿using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Helper.Validators.General.Implements;
using ClinicAppointment.Helper.Validators.General;
using ClinicAppointment.Menu.Interfaces;
using ClinicAppointment.Service.Interfaces;
using ClinicAppointment.Service.Services;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public class ConsCmdUpdateAppointment : IMenuCommand
    {
        public void Execute()
        {
            IDoctorService _doctorService = new DoctorService();
            IPatientService _patientService = new PatientService();
            IAppointmentService _appointmentService = new AppointmentService();
            Appointment? _appointment;

            IGeneralValidator<int> _validator = new GeneralValidatorId();
            Console.WriteLine("Please enter id of appointment:");
            int _appointmentId = _validator.Validate(Console.ReadLine());

            _appointment = _appointmentService.Get(_appointmentId);

            if (_appointment != null)
            {
                Console.WriteLine("Enter new ID of doctor for appointment:");
                _appointment.Doctor = ConsWorkWithObjects.GetUserById<IDoctorService, Doctor>(_doctorService);

                Console.WriteLine("Enter new ID of patient for appointment:");
                _appointment.Patient = ConsWorkWithObjects.GetUserById<IPatientService, Patient>(_patientService);

                IGeneralValidator<DateTime> _dateTimeValidator = new GeneralValidatorDateTime();
                Console.WriteLine("Enter new date and time for begin appointment (for example 20/12/2023 15:00):");
                _appointment.DateTimeFrom = _dateTimeValidator.Validate(Console.ReadLine());

                if (_appointment.DateTimeFrom.AddSeconds(60) < DateTime.Now)
                    throw new ArgumentException("Begin date and time can't be less than current");

                Console.WriteLine("Enter new date and time for end appointment (for example 20/12/2023 15:00):");
                _appointment.DateTimeTo = _dateTimeValidator.Validate(Console.ReadLine());

                if (_appointment.DateTimeTo < _appointment.DateTimeFrom)
                    throw new ArgumentException("End date and time can't be less than begin");

                Console.WriteLine("Please enter new additional information:");
                _appointment.Description = Console.ReadLine();

                _appointment = _appointmentService.Update(_appointmentId, _appointment);

                ConsWorkWithObjects.ResultObjectInform(_appointment, _appointmentService);
            }
            else
            {
                Console.WriteLine($"\nCouldn't find appointment with id {_appointmentId}");
            }
        }
    }
}
